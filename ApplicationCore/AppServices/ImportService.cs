﻿using Infrastructure.Dto.Filters;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Infrastructure.Repositories.CompanyRepository;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.AppServices
{
    public class ImportService : IImportService
    {
        private IProviderRepository _providerRepository;
        private ICompanyRepository _companyRepository;
        private IProductRepository _productRepository;

        public ImportService(
            IProviderRepository providerRepository,
            ICompanyRepository companyRepository,
            IProductRepository productRepository)
        {
            _providerRepository = providerRepository;
            _companyRepository = companyRepository;
            _productRepository = productRepository;
        }

        public bool Import(Provider provider)
        {
            if (provider == null)
                return false;

            var existingProvider = _providerRepository.GetProviderByFilter(new Filter()
            {
                ProviderNames = new List<string>() { provider.Name }
            });

            foreach (var company in provider.Companies)
            {
                company.ProviderId = existingProvider.Id;
            }

            var existingCompanies = _companyRepository.GetCompanies(new Filter()
            {
                ProviderNames = new List<string>() { provider.Name },
                CompanyGuids = provider.Companies.Select(c => c.Guid).ToList()
            });

            var existingCompaniesGuids = existingCompanies.Select(c => c.Guid);
            var newCompanies = provider.Companies.Where(c => !existingCompaniesGuids.Contains(c.Guid.ToLower())).ToArray();

            if (newCompanies.Any())
                _companyRepository.Add(newCompanies);

            foreach (var company in existingCompanies)
            {
                var providerCompany = provider.Companies.Single(c => c.Guid == company.Guid);
                foreach (var product in providerCompany.Products)
                {
                    product.CompanyId = company.Id;
                }

                var existingProducts = _productRepository.GetProducts(new Filter()
                {
                    ProductNames = new List<string>(providerCompany.Products.Select(p => p.Name)),
                    CompanyGuids = new List<string>() { providerCompany.Guid }
                });

                var existingProductNames = existingProducts.Select(p => p.Name);
                var newProducts = providerCompany.Products.Where(p => !existingProductNames.Contains(p.Name.ToLower())).ToArray();

                if (newProducts.Any())
                    _productRepository.Add(newProducts);

                foreach (var product in existingProducts)
                {
                    product.Amount += providerCompany.Products.Single(p => p.Name.ToLower() == product.Name.ToLower()).Amount;
                }

                _productRepository.Update(existingProducts);
            }

            return true;
        }
    }
}

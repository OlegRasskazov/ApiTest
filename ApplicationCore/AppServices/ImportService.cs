using Infrastructure.Models;
using Infrastructure.Dto.Filters;
using Infrastructure.Repositories;
using Infrastructure.Repositories.CompanyRepository;
using System.Linq;
using System.Collections.Generic;

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
            var existingProvider = _providerRepository.GetProviderByFilter(new Filter() {
                ProductNames = new List<string>(provider.Companies.SelectMany(c => c.Products).Select(p => p.Name).ToList()),
                CompanyGuids = provider.Companies.Select(c => c.Guid).ToList()
            });
            if (existingProvider == null)
                return false;


            //var existingCompanies = _companyRepository.GetCompanies(
            //    new Filter
            //    {
            //        CompanyGuids = ,
            //        ProviderIds = new List<int>() { existingProvider.Id }
            //    });
            //var existingProducts = _productRepository.GetProducts(new Filter() {
            //    ProductNames = ,
            //    CompanyIds = new List<int>(existingCompanies.Select(c => c.Id).ToList())
            //});

            

            return true;
        }
    }
}

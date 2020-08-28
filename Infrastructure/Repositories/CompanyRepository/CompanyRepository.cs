using Infrastructure.Db;
using Infrastructure.Dto.Filters;
using Infrastructure.Models;
using System;
using System.Linq;

namespace Infrastructure.Repositories.CompanyRepository
{
    public class CompanyRepository : ICompanyRepository
    {
        private DataContext _context;

        public CompanyRepository(DataContext ctx)
        {
            _context = ctx;
        }

        public void Add(Company[] companies)
        {
            _context.Companies.AddRange(companies);
            _context.SaveChanges();
        }

        public void Add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public Company[] GetCompanies(Filter filter)
        {
            return _context.Companies
                .Join(_context.Providers, c => c.ProviderId, p => p.Id, (c, p) => new { Company = c, Provider = p })
                .Where(p => filter.ProviderNames.Contains(p.Provider.Name) && filter.CompanyGuids.Contains(p.Company.Guid)).Select(c => c.Company).ToArray();

            //return _context.Companies.ApplyFilter(filter).ToArray();
        }

        public Company GetCompanyById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

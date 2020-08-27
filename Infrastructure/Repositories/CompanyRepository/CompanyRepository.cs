using Infrastructure.Db;
using Infrastructure.Dto.Filters;
using Infrastructure.Extensions;
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

        public Company[] GetCompanies(Filter filter)
        {
            return _context.Companies.ApplyFilter(filter).ToArray();
        }

        public Company GetCompanyById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

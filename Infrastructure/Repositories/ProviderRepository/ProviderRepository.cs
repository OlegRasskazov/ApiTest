using Infrastructure.Db;
using Infrastructure.Dto.Filters;
using Infrastructure.Extensions;
using Infrastructure.Models;
using System;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private DataContext _context;

        public ProviderRepository(DataContext context)
        {
            _context = context;
        }

        public Provider GetProvider(int id)
        {
            throw new NotImplementedException();
        }

        public Provider GetProviderByFilter(Filter filter)
        {
            //var x = _context.Providers.ApplyFilter(filter).ToSql();
            return _context.Providers.ApplyFilter(filter).FirstOrDefault();
        }

        public Provider[] GetProviders()
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(Provider provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }

    }
}

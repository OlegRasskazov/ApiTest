using Infrastructure.Db;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Provider GetProviderByName(string name)
        {
            return _context.Providers.FirstOrDefault(p => p.Name == name);
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

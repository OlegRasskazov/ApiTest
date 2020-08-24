using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private DataContext.DataContext _context;
        public ProviderRepository(DataContext.DataContext context)
        {
            _context = context;
        }
        public Provider GetProvider(int id)
        {
            throw new NotImplementedException();
        }

        public Provider[] GetProviders()
        {
            throw new NotImplementedException();
        }

        public void AddProvider(Provider provider)
        {
            _context.Providers.Add(provider);
            _context.SaveChanges();
        }

    }
}

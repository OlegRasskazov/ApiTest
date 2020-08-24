using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public interface IProviderRepository
    {
        Provider GetProvider(int id);

        Provider[] GetProviders();

        void AddProvider(Provider provider);
    }
}

using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public interface IProviderRepository
    {
        Provider GetProvider(int id);

        Provider GetProviderByName(string name);

        Provider[] GetProviders();

        void SaveOrUpdate(Provider provider);
    }
}

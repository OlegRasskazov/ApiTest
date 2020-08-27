using Infrastructure.Dto.Filters;
using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public interface IProviderRepository
    {
        Provider GetProvider(int id);

        Provider GetProviderByFilter(Filter filter);

        Provider[] GetProviders();

        void SaveOrUpdate(Provider provider);
    }
}

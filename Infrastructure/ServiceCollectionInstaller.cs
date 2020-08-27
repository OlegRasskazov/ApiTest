using Infrastructure.Repositories;
using Infrastructure.Repositories.CompanyRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionInstaller
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}

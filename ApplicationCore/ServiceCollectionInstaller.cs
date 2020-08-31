using ApplicationCore.AppServices;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore
{
    public static class ServiceCollectionInstaller
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IImportService, ImportService>();
        }
    }
}

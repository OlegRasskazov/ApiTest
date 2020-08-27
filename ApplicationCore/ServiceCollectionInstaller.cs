using ApplicationCore.AppServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

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

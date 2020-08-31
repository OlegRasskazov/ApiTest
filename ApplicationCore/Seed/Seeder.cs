using Infrastructure.Db;
using Infrastructure.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApplicationCore.Seed
{
    public static class Seeder
    {
        public static async void Seedit(IServiceProvider serviceProvider)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "SeedData.json");
            var jsonData = await File.ReadAllTextAsync(filePath);

            var providers = JsonConvert.DeserializeObject<List<Provider>>(jsonData);
            using (
             var serviceScope = serviceProvider
               .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                              .ServiceProvider.GetService<DataContext>();
                if (!context.Providers.Any())
                {
                    context.AddRange(providers);
                    context.SaveChanges();
                }
            }
        }
    }
}

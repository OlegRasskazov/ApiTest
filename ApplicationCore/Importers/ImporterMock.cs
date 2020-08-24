using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationCore.Importers
{
    public class ImporterMock : IImporter
    {
        public IList<Product> Import()
        {
            var provider = new Provider()
            {
                Name = "MockProvider",
                Companies = new List<Company>() {
                new Company()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Products = new List<Product>() {
                            new Product() {
                                LoadTime = DateTime.Now,
                                Name = "ProductA",
                                Amount = 2
                            },
                            new Product() {
                                LoadTime = DateTime.Now,
                                Name = "ProductB",
                                Amount = 3
                            }
                        }
                },
                    new Company()
                    {
                        Guid = Guid.NewGuid().ToString(),
                        Products = new List<Product>() {
                            new Product() {
                                LoadTime = DateTime.Now,
                                Name = "Productc",
                                Amount = 223
                            },
                            new Product() {
                                LoadTime = DateTime.Now,
                                Name = "Productd",
                                Amount = 333
                            }
                        }
                    }
                }
            };

            return provider.Companies.SelectMany(c => c.Products).ToList();
        }
    }
}

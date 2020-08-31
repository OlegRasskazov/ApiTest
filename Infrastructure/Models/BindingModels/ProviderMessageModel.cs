using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Models.BindingModels
{
    public class ProviderMessageModel
    {
        public Guid MessageId { get; set; }

        public string Name { get; set; }

        public DateTime LoadTime { get; set; }

        public Dictionary<string, ProductAModel[]> Companies { get; set; }

        public Provider GetProviderEntity()
        {
            return new Provider()
            {
                Name = this.Name,
                Companies = this.Companies.Select(c => new Company()
                {
                    Guid = c.Key,
                    Products = c.Value.Select(p => new Product()
                    {
                        Amount = p.Number,
                        Name = p.Value,
                        LoadTime = this.LoadTime
                    }).ToList()
                }).ToList(),
            };
        }
    }

    public class ProductAModel
    {
        public string Value { get; set; }

        public int Number { get; set; }
    }
}

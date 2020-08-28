using System;

namespace Infrastructure.Models
{
    //[JsonConverter(typeof(ProductConverter))]
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public DateTime LoadTime { get; set; }

        public int Amount { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }

    }
}

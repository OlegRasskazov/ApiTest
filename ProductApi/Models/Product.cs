using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class Product: EntityBase
    {
        public string Name { get; set; }
        public DateTime LoadTime { get; set; }
        public int Amount { get; set; }
        public Company Company { get; set; }

    }
}

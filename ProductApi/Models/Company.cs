using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class Company: EntityBase
    {
        public string Guid { get; set; }
        public IList<Product> Products { get; set; }
        public Provider Provider { get; set; }
    }
}

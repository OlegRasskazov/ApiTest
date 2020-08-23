using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models
{
    public class Provider: EntityBase
    {
        public string Name { get; set; }
        public IList<Company> Companies{ get; set; }
    }
}

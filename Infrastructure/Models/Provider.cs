using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class Provider : EntityBase
    {
        public string Name { get; set; }
        public IList<Company> Companies { get; set; }
    }
}

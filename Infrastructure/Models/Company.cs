using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class Company : EntityBase
    {
        public string Guid { get; set; }

        public IList<Product> Products { get; set; }

        public Provider Provider { get; set; }

        public int ProviderId { get; set; }
    }
}

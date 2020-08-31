using System.Collections.Generic;

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

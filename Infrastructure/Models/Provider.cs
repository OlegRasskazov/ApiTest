using System.Collections.Generic;

namespace Infrastructure.Models
{
    public class Provider : EntityBase
    {
        public string Name { get; set; }

        public IList<Company> Companies { get; set; }
    }
}

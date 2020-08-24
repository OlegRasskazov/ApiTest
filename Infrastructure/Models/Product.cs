using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public DateTime LoadTime { get; set; }
        public int Amount { get; set; }
        public Company Company { get; set; }

    }
}

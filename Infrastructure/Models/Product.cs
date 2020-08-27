using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Dto;

namespace Infrastructure.Models
{
    //[JsonConverter(typeof(ProductConverter))]
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public DateTime LoadTime { get; set; }
        public int Amount { get; set; }
        public Company Company { get; set; }

    }
}

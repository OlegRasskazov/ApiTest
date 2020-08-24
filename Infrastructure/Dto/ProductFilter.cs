using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto
{
    public class Filter
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public string Name { get; set; }
    }
}

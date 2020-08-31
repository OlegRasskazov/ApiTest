using System;
using System.Collections.Generic;

namespace Infrastructure.Dto.Filters
{
    public class Filter
    {
        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public IList<string> ProductNames { get; set; }

        public IList<int> ProductIds { get; set; }

        public IList<string> CompanyGuids { get; set; }

        public IList<int> CompanyIds { get; set; }

        public IList<string> ProviderNames { get; set; }

        public IList<int> ProviderIds { get; set; }
    }
}

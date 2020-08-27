using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dto.Filters
{
    public class CompanyFilter
    {
        public IList<string> Guids { get; set; }

        public string ProviderName { get; set; }
    }
}

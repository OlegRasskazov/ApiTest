﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Models.Bindings
{
    public class GetProviderQueryObject
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}

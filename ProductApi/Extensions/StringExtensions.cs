using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ProductApi.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Compare(this string str, string s) {
            return str.ToLower().Equals(s, StringComparison.OrdinalIgnoreCase);
        }
    }
}

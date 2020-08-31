using System;

namespace Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }

        public static bool Compare(this string str, string s)
        {
            return str.ToLower().Equals(s, StringComparison.OrdinalIgnoreCase);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.Blazor.Extensions
{
    public static class EnumerableExtensions
    {
        public static string JoinAsString(this IEnumerable<string> source, string separator)
        {
            string result = null;
            foreach (var item in source)
            {
                result = result + separator + item;
            }
            return result;
        }
    }
}

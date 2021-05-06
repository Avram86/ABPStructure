using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Structure.API.ExtensionMethods
{
    public static class ExtensionLinq
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (condition)
            { query.Where(predicate); }
            return query;
        }
    }

    public static class ExtensionEnumerable
    {
        public static string JoinAsString(this IEnumerable<string> source, string separator)
        {
            string result = null;
            foreach(var item in source)
            {
                result = result + separator + item;
            }
            return result;
        }
    }
}

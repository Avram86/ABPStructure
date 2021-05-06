using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Domain.Shared.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            return query.Skip(skipCount).Take(maxResultCount);
            //
            // Summary:
            //     Used for paging. Can be used as an alternative to Skip(...).Take(...) chaining.
        }
        public static IQueryable<T> PageBy<T, IQueryable>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            query = query.Skip(skipCount).Take(maxResultCount).AsQueryable<T>();
            return query;
        }
    }
}

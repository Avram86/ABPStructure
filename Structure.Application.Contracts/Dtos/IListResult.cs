using System.Collections.Generic;

namespace Structure.Application.Dtos
{
    public interface IListResult<T>
    {
        //
        // Summary:
        //     List of items.
        IReadOnlyList<T> Items { get; set; }
    }
}
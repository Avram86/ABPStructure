namespace Structure.Application.Dtos
{
    //
    // Summary:
    //     This interface is defined to standardize to return a page of items to clients.
    //
    // Type parameters:
    //   T:
    //     Type of the items in the Volo.Abp.Application.Dtos.IListResult`1.Items list
    public interface IPagedResult<T> : IListResult<T>, IHasTotalCount
    {
    }
}
namespace Structure.Application.Dtos
{
    public interface IPagedAndSortedResultRequest : IPagedResultRequest, ILimitedResultRequest, ISortedResultRequest
    {
    }
}
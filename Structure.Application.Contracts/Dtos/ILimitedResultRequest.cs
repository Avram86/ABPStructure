namespace Structure.Application.Dtos
{
    public interface ILimitedResultRequest
    {
        //
        // Summary:
        //     Maximum result count should be returned. This is generally used to limit result
        //     count on paging.
        int MaxResultCount { get; set; }
    }
}
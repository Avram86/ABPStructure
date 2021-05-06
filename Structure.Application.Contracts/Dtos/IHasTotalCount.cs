namespace Structure.Application.Dtos
{
    //
    // Summary:
    //     This interface is defined to standardize to set "Total Count of Items" to a DTO.
    public interface IHasTotalCount
    {
        //
        // Summary:
        //     Total count of Items.
        long TotalCount { get; set; }
    }
}
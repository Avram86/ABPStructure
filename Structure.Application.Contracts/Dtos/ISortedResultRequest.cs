namespace Structure.Application.Dtos
{
    public interface ISortedResultRequest
    {
        //
        // Summary:
        //     Sorting information. Should include sorting field and optionally a direction
        //     (ASC or DESC) Can contain more than one field separated by comma (,).
        string Sorting { get; set; }
    }
}
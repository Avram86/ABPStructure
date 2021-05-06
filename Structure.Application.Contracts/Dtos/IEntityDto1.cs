namespace Structure.Application.Contracts.Dtos
{
    internal interface IEntityDto<TKey>:IEntityDto
    {
        TKey Id { get; set; }
    }
}
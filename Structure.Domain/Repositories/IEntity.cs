namespace Structure.Domain.Entities
{//
    // Summary:
    //     Defines an entity. It's primary key may not be "Id" or it may have a composite
    //     primary key. Use Volo.Abp.Domain.Entities.IEntity`1 where possible for better
    //     integration to repositories and other structures in the framework.
    public interface IEntity
    {
        //
        // Summary:
        //     Returns an array of ordered keys for this entity.
        object[] GetKeys();
    }
}
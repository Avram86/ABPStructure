using Structure.Domain.Entities;

namespace Structure.Domain.Repositories
{
     public interface IEntity<TKey> : IEntity
        {
            //
            // Summary:
            //     Unique identifier for this entity.
            TKey Id { get; }
        }
    
}
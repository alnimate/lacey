using Lacey.Medusa.Common.Domain.Interfaces;

namespace Lacey.Medusa.Common.Domain.Entities
{
    public abstract class Entity<TId> : IIdEntity<TId>
    {
        public virtual TId Id { get; set; }

        public virtual bool IsNew()
        {
            return this.Id.Equals(default(TId));
        }
    }
}
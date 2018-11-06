using Lacey.Medusa.Common.Dal.Dal;

namespace Lacey.Medusa.Common.Services.Services.Lists
{
    using Domain.Entities;
    using Lacey.Medusa.Common.Domain.Interfaces;

    public abstract class LongIdNoRequestListService<TEntity>
        : NoRequestListService<TEntity, long>
        where TEntity : LongIdEntity, INamedEntity
    {
        protected LongIdNoRequestListService(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }
    }
}
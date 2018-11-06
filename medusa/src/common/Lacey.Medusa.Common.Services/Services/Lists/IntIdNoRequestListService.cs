using Lacey.Medusa.Common.Dal.Dal;

namespace Lacey.Medusa.Common.Services.Services.Lists
{
    using Domain.Entities;
    using Lacey.Medusa.Common.Domain.Interfaces;

    public abstract class IntIdNoRequestListService<TEntity>
        : NoRequestListService<TEntity, int>
        where TEntity : IntIdEntity, INamedEntity
    {
        protected IntIdNoRequestListService(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }
    }
}
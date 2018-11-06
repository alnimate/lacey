using Lacey.Medusa.Common.Dal.Dal;

namespace Lacey.Medusa.Common.Services.Services.Lists
{
    using System;
    using Domain.Entities;
    using Lacey.Medusa.Common.Domain.Interfaces;

    public abstract class GuidIdNoRequestListService<TEntity>
        : NoRequestListService<TEntity, Guid>
        where TEntity : GuidIdEntity, INamedEntity
    {
        protected GuidIdNoRequestListService(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }
    }
}
namespace Lacey.Medusa.Common.Services.Services.Lists
{
    using Dal.Infrastructure;
    using Domain.Entities;
    using Lacey.Medusa.Common.Domain.Interfaces;
    using Lacey.Medusa.Common.Services.Models.Lists;

    public abstract class NoRequestListService<TEntity, TId>
        : ModelsListService<TEntity, TId, EmptyListRequest>
        where TEntity : Entity<TId>, INamedEntity
    {
        protected NoRequestListService(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }
    }
}
namespace Lacey.Medusa.Common.Services.Services.Lists
{
    using System;
    using Dal.Infrastructure;
    using Domain.Entities;
    using Lacey.Medusa.Common.Domain.Interfaces;

    public abstract class GuidIdModelsListService<TEntity, TRequest>
        : ModelsListService<TEntity, Guid, TRequest>
        where TEntity : GuidIdEntity, INamedEntity
    {
        protected GuidIdModelsListService(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
        }
    }
}
namespace Lacey.Medusa.Common.Services.Services.Lists
{
    using Dal.Infrastructure;
    using Domain.Entities;
    using Lacey.Medusa.Common.Domain.Interfaces;

    public abstract class IntIdModelsListService<TEntity, TRequest>
        : ModelsListService<TEntity, int, TRequest>
        where TEntity : IntIdEntity, INamedEntity
    {
        protected IntIdModelsListService(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
        }
    }
}
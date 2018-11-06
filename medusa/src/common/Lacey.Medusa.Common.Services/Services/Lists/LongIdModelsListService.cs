using Lacey.Medusa.Common.Dal.Dal;

namespace Lacey.Medusa.Common.Services.Services.Lists
{
    using Domain.Entities;
    using Lacey.Medusa.Common.Domain.Interfaces;

    public abstract class LongIdModelsListService<TEntity, TRequest>
        : ModelsListService<TEntity, long, TRequest>
        where TEntity : LongIdEntity, INamedEntity
    {
        protected LongIdModelsListService(IUnitOfWorkFactory unitOfWorkFactory) : base(unitOfWorkFactory)
        {
        }
    }
}
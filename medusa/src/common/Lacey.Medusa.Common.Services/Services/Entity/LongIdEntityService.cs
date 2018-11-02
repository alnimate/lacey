namespace Lacey.Medusa.Common.Services.Services.Entity
{
    using AutoMapper;

    using Dal.Infrastructure;
    using Domain.Entities;
    using Models.Business;

    public abstract class LongIdEntityService<TEntity, TModel, TOverviewsRequest, TOverviews>
        : EntityService<TEntity, TModel, long, TOverviewsRequest, TOverviews>
        where TEntity : LongIdEntity
        where TModel : LongIdBusinessModel
    {
        protected LongIdEntityService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
            : base(unitOfWorkFactory, mapper)
        {
        }
    }
}
namespace Lacey.Medusa.Common.Services.Services.Entity
{
    using AutoMapper;

    using Dal.Infrastructure;
    using Domain.Entities;
    using Models.Business;

    public abstract class IntIdEntityService<TEntity, TModel, TOverviewsRequest, TOverviews>
        : EntityService<TEntity, TModel, int, TOverviewsRequest, TOverviews>
        where TEntity : IntIdEntity
        where TModel : IntIdBusinessModel
    {
        protected IntIdEntityService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
            : base(unitOfWorkFactory, mapper)
        {
        }
    }
}
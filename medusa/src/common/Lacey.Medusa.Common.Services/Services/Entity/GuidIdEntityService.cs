using Lacey.Medusa.Common.Dal.Dal;

namespace Lacey.Medusa.Common.Services.Services.Entity
{
    using System;

    using AutoMapper;
    using Domain.Entities;
    using Models.Business;

    public abstract class GuidIdEntityService<TEntity, TModel, TOverviewsRequest, TOverviews>
        : EntityService<TEntity, TModel, Guid, TOverviewsRequest, TOverviews>
        where TEntity : GuidIdEntity
        where TModel : GuidIdBusinessModel
    {
        protected GuidIdEntityService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
            : base(unitOfWorkFactory, mapper)
        {
        }
    }
}
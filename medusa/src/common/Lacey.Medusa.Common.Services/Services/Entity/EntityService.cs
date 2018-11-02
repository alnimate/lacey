namespace Lacey.Medusa.Common.Services.Services.Entity
{
    using System.Threading.Tasks;

    using AutoMapper;

    using Dal.Infrastructure;
    using Domain.Entities;
    using Models.Business;
    using Common;
    using Interfaces;

    public abstract class EntityService<TEntity, TModel, TId, TOverviewsRequest, TOverviews>
        : UnitOfWorkService, IEntityService<TModel, TId, TOverviewsRequest, TOverviews>
        where TEntity : Entity<TId>
        where TModel : BusinessModel<TId>
    {
        protected readonly IMapper Mapper;

        protected EntityService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
            : base(unitOfWorkFactory)
        {
            this.Mapper = mapper;
        }

        protected abstract Task<TOverviews> DoGetOverviews(IUnitOfWork uow, TOverviewsRequest request);

        public virtual async Task<TOverviews> GetOverviews(TOverviewsRequest request)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                return await this.DoGetOverviews(uow, request);
            }
        }

        public virtual async Task<TModel> Read(TId id)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var rep = uow.GetRepository<TEntity>();

                var entity = await rep.GetByIdAsync(id);
                var model = this.Mapper.Map<TModel>(entity);

                return model;
            }
        }

        public virtual async Task<TModel> CreateOrUpdate(TModel model)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var customersRep = uow.GetRepository<TEntity>();
                var entity = this.Mapper.Map<TEntity>(model);
                if (model.IsNew())
                {
                    customersRep.Add(entity);
                }
                else
                {
                    customersRep.Update(entity);
                }

                await uow.SaveAsync();
                model.UpdateId(entity.Id);
                return model;
            }
        }

        public virtual async Task Delete(TId id)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var rep = uow.GetRepository<TEntity>();

                rep.DeleteById(id);
                await uow.SaveAsync();
            }
        }
    }
}
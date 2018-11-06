using Lacey.Medusa.Common.Dal.Dal;

namespace Lacey.Medusa.Common.Services.Services.Lists
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Lacey.Medusa.Common.Domain.Interfaces;
    using Mappers;
    using Lacey.Medusa.Common.Services.Models.Lists;
    using Common;
    using Interfaces;

    public abstract class PersonsListService<TEntity, TId, TRequest>
        : UnitOfWorkService, IModelsListService<TRequest>
        where TEntity : Entity<TId>, INamedPerson
    {
        protected PersonsListService(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        protected virtual IQueryable<TEntity> GetEntitiesQuery(IRepository<TEntity> rep, TRequest request)
        {
            return rep.GetAll();
        }

        public virtual async Task<ModelsList<TRequest>> GetList(TRequest request)
        {
            using (var uow = this.CreateWithDisabledLazyLoading())
            {
                var rep = uow.GetRepository<TEntity>();

                return await ModelsListMapper.MapToPersonsList<TEntity, TId, TRequest>(
                           this.GetEntitiesQuery(rep, request),
                           request);
            }
        }
    }
}
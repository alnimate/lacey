using AutoMapper;
using Lacey.Medusa.Common.Services.Models.Business;
using Lacey.Medusa.Common.Services.Services.Entity.Interfaces;

namespace Lacey.Medusa.Common.Web.Controllers.Entity
{
    public abstract class LongIdEntityApiController
        <TService, TModel, TOverviewsRequest, TOverviews, TResource, TOverviewsRequestResource, TOverviewsResource> :
            EntityApiController<TService, TModel, long, TOverviewsRequest, TOverviews, TResource, TOverviewsRequestResource, TOverviewsResource>
        where TService : ILongIdEntityService<TModel, TOverviewsRequest, TOverviews>
        where TModel : LongIdBusinessModel
    {
        protected LongIdEntityApiController(TService service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}
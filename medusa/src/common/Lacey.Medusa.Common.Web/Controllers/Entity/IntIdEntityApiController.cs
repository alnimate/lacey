using AutoMapper;
using Lacey.Medusa.Common.Services.Models.Business;
using Lacey.Medusa.Common.Services.Services.Entity.Interfaces;

namespace Lacey.Medusa.Common.Web.Controllers.Entity
{
    public abstract class IntIdEntityApiController
        <TService, TModel, TOverviewsRequest, TOverviews, TResource, TOverviewsRequestResource, TOverviewsResource> : 
            EntityApiController<TService, TModel, int, TOverviewsRequest, TOverviews, TResource, TOverviewsRequestResource, TOverviewsResource>
        where TService : IIntIdEntityService<TModel, TOverviewsRequest, TOverviews> 
        where TModel : IntIdBusinessModel
    {
        protected IntIdEntityApiController(TService service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}
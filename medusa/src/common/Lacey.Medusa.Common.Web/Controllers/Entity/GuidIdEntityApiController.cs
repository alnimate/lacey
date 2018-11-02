using System;
using AutoMapper;
using Lacey.Medusa.Common.Services.Models.Business;
using Lacey.Medusa.Common.Services.Services.Entity.Interfaces;

namespace Lacey.Medusa.Common.Web.Controllers.Entity
{
    public abstract class GuidIdEntityApiController
        <TService, TModel, TOverviewsRequest, TOverviews, TResource, TOverviewsRequestResource, TOverviewsResource> :
            EntityApiController<TService, TModel, Guid, TOverviewsRequest, TOverviews, TResource, TOverviewsRequestResource, TOverviewsResource>
        where TService : IGuidIdEntityService<TModel, TOverviewsRequest, TOverviews>
        where TModel : GuidIdBusinessModel
    {
        protected GuidIdEntityApiController(TService service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}
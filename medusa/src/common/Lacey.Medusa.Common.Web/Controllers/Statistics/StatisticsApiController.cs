using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Common.Resources.Resources.Statistics;
using Lacey.Medusa.Common.Services.Services.Statistics.Interfaces;
using Lacey.Medusa.Common.Web.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Lacey.Medusa.Common.Web.Controllers.Statistics
{
    public abstract class StatisticsApiController<TService, TRequest, TRequestResource, TData>
        : ApiController
        where TService : IStatisticsService<TRequest, TData>
    {
        protected readonly TService Service;

        protected readonly IMapper Mapper;

        protected StatisticsApiController(TService service, IMapper mapper)
        {
            this.Service = service;
            this.Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get([FromQuery] TRequestResource requestResource)
        {
            var request = this.Mapper.Map<TRequest>(requestResource);
            var model = await this.Service.GetStatistics(request);
            var resource = this.Mapper.Map<StatisticsResource<TRequest, TData>>(model);

            return this.Ok(resource);
        }
    }
}
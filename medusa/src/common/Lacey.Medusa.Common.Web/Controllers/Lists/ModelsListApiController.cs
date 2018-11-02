using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Common.Resources.Resources.Lists;
using Lacey.Medusa.Common.Services.Services.Lists.Interfaces;
using Lacey.Medusa.Common.Web.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Lacey.Medusa.Common.Web.Controllers.Lists
{
    public abstract class ModelsListApiController<TService, TRequest, TRequestResource>
        : ApiController
        where TService : IModelsListService<TRequest>
    {
        protected readonly TService Service;

        protected readonly IMapper Mapper;

        protected ModelsListApiController(TService service, IMapper mapper)
        {
            this.Service = service;
            this.Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get([FromQuery] TRequestResource requestResource)
        {
            var request = this.Mapper.Map<TRequest>(requestResource);
            var model = await this.Service.GetList(request);
            var resource = this.Mapper.Map<ModelsListResource<TRequest>>(model);

            return this.Ok(resource);
        }
    }
}
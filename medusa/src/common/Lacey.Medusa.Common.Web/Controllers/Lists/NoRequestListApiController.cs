using AutoMapper;
using Lacey.Medusa.Common.Resources.Resources.Lists;
using Lacey.Medusa.Common.Services.Models.Lists;
using Lacey.Medusa.Common.Services.Services.Lists.Interfaces;

namespace Lacey.Medusa.Common.Web.Controllers.Lists
{
    public abstract class NoRequestListApiController<TService>
        : ModelsListApiController<TService, EmptyListRequest, EmptyListRequestResource>
        where TService : INoRequestListService
    {
        protected NoRequestListApiController(TService service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}
using Lacey.Medusa.Common.Api.Base.Services;

namespace Lacey.Medusa.Common.Core.Api
{
    public abstract class ApiResource
    {
        protected readonly IClientService Service;

        protected ApiResource(IClientService service)
        {
            Service = service;
        }
    }
}
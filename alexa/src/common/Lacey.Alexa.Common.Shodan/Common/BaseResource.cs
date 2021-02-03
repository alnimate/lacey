using Lacey.Medusa.Common.Api.Base.Services;

namespace Lacey.Alexa.Common.Shodan.Common
{
    public abstract class BaseResource
    {
        protected readonly IClientService Service;

        protected BaseResource(IClientService service)
        {
            Service = service;
        }
    }
}
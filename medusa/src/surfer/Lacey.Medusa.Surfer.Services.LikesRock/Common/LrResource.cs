using Lacey.Medusa.Common.Api.Base.Services;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Common
{
    public abstract class LrResource
    {
        protected readonly IClientService Service;

        protected LrResource(IClientService service)
        {
            Service = service;
        }
    }
}
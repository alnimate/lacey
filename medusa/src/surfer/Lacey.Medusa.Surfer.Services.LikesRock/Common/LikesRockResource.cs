using Lacey.Medusa.Common.Api.Base.Services;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Common
{
    public abstract class LikesRockResource
    {
        protected readonly IClientService Service;

        protected LikesRockResource(IClientService service)
        {
            Service = service;
        }
    }
}
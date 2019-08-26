using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Base.Services;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Resources
{
    public abstract class LikesRockRequest<TResponse> : ClientServiceRequest<TResponse>
    {
        protected LikesRockRequest(IClientService service) : base(service)
        {
        }
    }
}
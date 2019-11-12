using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Base.Services;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Common
{
    public abstract class LrRequest<TResponse> : ClientServiceRequest<TResponse>
    {
        protected LrRequest(IClientService service) : base(service)
        {
            base.InitParameters();
        }

        public override string MethodName => "";
    }
}
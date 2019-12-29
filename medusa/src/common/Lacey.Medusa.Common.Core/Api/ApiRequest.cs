using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Base.Services;

namespace Lacey.Medusa.Common.Core.Api
{
    public abstract class ApiRequest<TResponse> : ClientServiceRequest<TResponse>
    {
        protected ApiRequest(IClientService service) : base(service)
        {
            base.InitParameters();
        }

        public override string MethodName => "";
    }
}
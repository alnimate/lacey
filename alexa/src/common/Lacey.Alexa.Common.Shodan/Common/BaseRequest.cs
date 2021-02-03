using Lacey.Medusa.Common.Api.Base.Requests;
using Lacey.Medusa.Common.Api.Base.Services;

namespace Lacey.Alexa.Common.Shodan.Common
{
    public abstract class BaseRequest<TResponse> : ClientServiceRequest<TResponse>
    {
        protected BaseRequest(IClientService service) : base(service)
        {
            base.InitParameters();
        }

        public override string MethodName => "";
    }
}
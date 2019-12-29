using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Core.Api;
using Lacey.Medusa.MakeMoney.Services.Models.ScDevice;

namespace Lacey.Medusa.MakeMoney.Services.Resources
{
    public sealed class ScDeviceResource : ApiResource
    {
        public ScDeviceResource(IClientService service) : base(service)
        {
        }

        public ScDeviceApiRequest ScDevice(ScDeviceRequest request)
        {
            return new ScDeviceApiRequest(this.Service, request);
        }


        public sealed class ScDeviceApiRequest : ApiRequest<ScDeviceResponse>
        {
            private readonly ScDeviceRequest body;

            public ScDeviceApiRequest(
                IClientService service,
                ScDeviceRequest request) : base(service)
            {
                this.body = request;
            }

            public override string RestPath => "SC_Device";

            public override string HttpMethod => HttpConsts.Post;

            protected override object GetBody()
            {
                return this.body;
            }
        }
    }
}
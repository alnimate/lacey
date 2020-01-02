using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Core.Api;
using Lacey.Medusa.MakeMoney.Services.Models.ScNewsAndroid;

namespace Lacey.Medusa.MakeMoney.Services.Resources
{
    public sealed class ScNewsAndroidResource : ApiResource
    {
        public ScNewsAndroidResource(IClientService service) : base(service)
        {
        }

        public ScNewsAndroidApiRequest ScNewsAndroid(ScNewsAndroidRequest request)
        {
            return new ScNewsAndroidApiRequest(this.Service, request);
        }

        public sealed class ScNewsAndroidApiRequest : ApiRequest<ScNewsAndroidResponse>
        {
            private readonly ScNewsAndroidRequest body;

            public ScNewsAndroidApiRequest(
                IClientService service,
                ScNewsAndroidRequest request) : base(service)
            {
                this.body = request;
            }

            public override string RestPath => "SC_NewsAndroid";

            public override string HttpMethod => HttpConsts.Post;

            protected override object GetBody()
            {
                return this.body;
            }
        }
    }
}
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Core.Api;
using Lacey.Medusa.MakeMoney.Services.Models.ScSaveFirebaseToken;

namespace Lacey.Medusa.MakeMoney.Services.Resources
{
    public sealed class ScSaveFirebaseTokenResource : ApiResource
    {
        public ScSaveFirebaseTokenResource(IClientService service) : base(service)
        {
        }

        public ScSaveFirebaseTokenApiRequest ScSaveFirebaseToken(ScSaveFirebaseTokenRequest request)
        {
            return new ScSaveFirebaseTokenApiRequest(this.Service, request);
        }

        public sealed class ScSaveFirebaseTokenApiRequest : ApiRequest<ScSaveFirebaseTokenResponse>
        {
            private readonly ScSaveFirebaseTokenRequest body;

            public ScSaveFirebaseTokenApiRequest(
                IClientService service,
                ScSaveFirebaseTokenRequest request) : base(service)
            {
                this.body = request;
            }

            public override string RestPath => "SC_SaveFirebaseToken";

            public override string HttpMethod => HttpConsts.Post;

            protected override object GetBody()
            {
                return this.body;
            }
        }
    }
}
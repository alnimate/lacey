using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Core.Api;
using Lacey.Medusa.MakeMoney.Services.Models.ScBalance;

namespace Lacey.Medusa.MakeMoney.Services.Resources
{
    public sealed class ScBalanceResource : ApiResource
    {
        public ScBalanceResource(IClientService service) : base(service)
        {
        }

        public ScBalanceApiRequest ScBalance(ScBalanceRequest request)
        {
            return new ScBalanceApiRequest(this.Service, request);
        }

        public sealed class ScBalanceApiRequest : ApiRequest<ScBalanceResponse>
        {
            private readonly ScBalanceRequest body;

            public ScBalanceApiRequest(
                IClientService service,
                ScBalanceRequest request) : base(service)
            {
                this.body = request;
            }

            public override string RestPath => "SC_Balance";

            public override string HttpMethod => HttpConsts.Post;

            protected override object GetBody()
            {
                return this.body;
            }
        }
    }
}
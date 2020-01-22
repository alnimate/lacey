using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Discovery;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Api.Core.Base.Util;
using Lacey.Medusa.Common.Core.Api;
using Lacey.Medusa.Vendor.AdColony.Models.Events3.Rewardv4vc;

namespace Lacey.Medusa.Vendor.AdColony.Resources.Events3
{
    public sealed class Rewardv4VcResource : ApiResource
    {
        public Rewardv4VcResource(IClientService service) : base(service)
        {
        }

        public Rewardv4VcRequest Rewardv4Vc(string pl, Rewardv4VcRequestModel request)
        {
            return new Rewardv4VcRequest(this.Service, pl, request);
        }

        public sealed class Rewardv4VcRequest : ApiRequest<Rewardv4VcModel>
        {
            private readonly Rewardv4VcRequestModel body;

            public Rewardv4VcRequest(
                IClientService service,
                string pl,
                Rewardv4VcRequestModel body) : base(service)
            {
                Pl = pl;
                this.body = body;

                this.RequestParameters.Add("pl", new Parameter
                {
                    Name = "pl",
                    IsRequired = true,
                    ParameterType = "query",
                    DefaultValue = null,
                    Pattern = null
                });
            }

            public override string RestPath => "reward_v4vc";

            public override string HttpMethod => HttpConsts.Post;

            [RequestParameter("pl", RequestParameterType.Query)]
            public string Pl { get; private set; }

            protected override object GetBody()
            {
                return this.body;
            }
        }
    }
}
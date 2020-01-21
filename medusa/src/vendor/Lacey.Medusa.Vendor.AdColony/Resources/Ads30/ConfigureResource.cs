using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Base.Http;
using Lacey.Medusa.Common.Core.Api;
using Lacey.Medusa.Vendor.AdColony.Models.Ads30.Configure;

namespace Lacey.Medusa.Vendor.AdColony.Resources.Ads30
{
    public sealed class ConfigureResource : ApiResource
    {
        public ConfigureResource(IClientService service) : base(service)
        {
        }

        public ConfigureRequest Configure(ConfigureRequestModel request)
        {
            return new ConfigureRequest(this.Service, request);
        }

        public sealed class ConfigureRequest : ApiRequest<ConfigureModel>
        {
            private readonly ConfigureRequestModel body;

            public ConfigureRequest(
                IClientService service, 
                ConfigureRequestModel body) : base(service)
            {
                this.body = body;
            }

            public override string RestPath => "configure";

            public override string HttpMethod => HttpConsts.Post;

            protected override object GetBody()
            {
                return this.body;
            }
        }
    }
}
using Lacey.Medusa.Common.Core.Api;
using Lacey.Medusa.Vendor.AdColony.Resources.Ads30;

namespace Lacey.Medusa.Vendor.AdColony.Providers
{
    public sealed class Ads30Provider : ApiProvider
    {
        public Ads30Provider(Initializer initializer) : base(initializer)
        {
            this.Configure = new ConfigureResource(this);
        }

        public override string Name => "Ads30";

        public override string BaseUri => "https://ads30.adcolony.com/";

        public override string BasePath => "/";

        public ConfigureResource Configure { get; }
    }
}
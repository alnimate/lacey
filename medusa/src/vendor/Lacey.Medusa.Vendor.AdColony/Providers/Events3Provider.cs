using Lacey.Medusa.Common.Core.Api;
using Lacey.Medusa.Vendor.AdColony.Resources.Events3;

namespace Lacey.Medusa.Vendor.AdColony.Providers
{
    public sealed class Events3Provider : ApiProvider
    {
        public Events3Provider(Initializer initializer) : base(initializer)
        {
            this.Rewardv4Vc = new Rewardv4VcResource(this);
        }

        public override string Name => "Events3";

        public override string BaseUri => "https://events3.adcolony.com/t/5.0/";

        public override string BasePath => "t/5.0/";

        public Rewardv4VcResource Rewardv4Vc { get; }
    }
}
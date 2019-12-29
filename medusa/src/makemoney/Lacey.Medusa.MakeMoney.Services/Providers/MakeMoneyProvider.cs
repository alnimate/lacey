using Lacey.Medusa.Common.Core.Api;
using Lacey.Medusa.MakeMoney.Services.Resources;

namespace Lacey.Medusa.MakeMoney.Services.Providers
{
    public sealed class MakeMoneyProvider : ApiProvider
    {
        public MakeMoneyProvider(Initializer initializer) : base(initializer)
        {
            this.ScDevice = new ScDeviceResource(this);
        }

        public override string Name => "MakeMoney";

        public override string BaseUri => "https://makemoney.mobu-app.com:60001/MAKEMONEY_CONTROL/";

        public override string BasePath => "MAKEMONEY_CONTROL/";

        public ScDeviceResource ScDevice { get; }
    }
}
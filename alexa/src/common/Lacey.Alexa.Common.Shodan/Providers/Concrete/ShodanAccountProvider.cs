using System.Collections.Generic;
using Lacey.Alexa.Common.Shodan.Resources;
using Lacey.Medusa.Common.Api.Base.Services;

namespace Lacey.Alexa.Common.Shodan.Providers.Concrete
{
    public sealed class ShodanAccountProvider : BaseClientService
    {
        public ShodanAccountProvider(Initializer initializer) : base(initializer)
        {
            Login = new LoginResource(this);
        }

        public override string Name => "ShodanAccount";

        public override string BaseUri => "https://account.shodan.io/";

        public override string BasePath => "/";

        public override IList<string> Features => new string[0];

        public LoginResource Login { get; }
    }
}
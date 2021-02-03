using Lacey.Alexa.Common.Shodan.Models.Login;
using Lacey.Alexa.Common.Shodan.Providers;
using Lacey.Alexa.Common.Shodan.Providers.Concrete;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Custom.Serializers;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Common.Shodan.Common
{
    public abstract class BaseService
    {
        protected readonly ILogger _logger;

        protected readonly (string Username, string Password) Credentials;

        protected readonly ShodanAccountProvider AccountProvider;

        protected static LoginResponseModel UserSession { get; set; }

        protected BaseService(
            IShodanAuthProvider authProvider, 
            ILogger logger)
        {
            _logger = logger;

            Credentials = authProvider.GetCredentials();

            AccountProvider = new ShodanAccountProvider(
                new BaseClientService.Initializer
                {
                    Serializer = new WebFormsToJsonSerializer()
                });
        }

        public bool IsAuthenticated()
        {
            return UserSession != null;
        }
    }
}
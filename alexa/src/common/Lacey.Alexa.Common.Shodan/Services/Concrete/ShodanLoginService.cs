using System.IO;
using System.Threading.Tasks;
using Lacey.Alexa.Common.Shodan.Common;
using Lacey.Alexa.Common.Shodan.Extensions;
using Lacey.Alexa.Common.Shodan.Models.Login;
using Lacey.Alexa.Common.Shodan.Providers;
using Lacey.Alexa.Common.Shodan.Serializers;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Common.Core.Extensions;
using Lacey.Medusa.Common.Core.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Lacey.Alexa.Common.Shodan.Services.Concrete
{
    public sealed class ShodanLoginService : BaseService, IShodanLoginService
    {
        private readonly string _sessionFilePath;

        public ShodanLoginService(
            string sessionFilePath,
            IShodanAuthProvider authProvider, 
            ILogger logger) : base(authProvider, logger)
        {
            this._sessionFilePath = sessionFilePath;
        }

        public async Task Login()
        {
            if (IsAuthenticated())
            {
                return;
            }

            await ProceedUtils.Proceed<bool?>(_logger, async () =>
            {
                var session = this.LoadSession();
                if (session != null)
                {
                    UserSession = session;
                    _logger.LogTrace(UserSession.GetLog());
                    return true;
                }

                var loginGetRequest = AccountProvider.Login.LoginGet()
                    .SetDefault()
                    .SetSerializer(new LoginGetSerializer());
                var loginGet = await loginGetRequest.ExecuteAsync();

                var loginRequest = AccountProvider.Login.Login(
                    Credentials.Username,
                    Credentials.Password,
                    loginGet.GrantType,
                    loginGet.Continue,
                    loginGet.CsrfToken)
                    .SetDefault();
                var loginResult = await loginRequest.ExecuteUnparsedAsync();
                var politoCookie = loginResult.GetCookie("polito");
                var sessionCookie = loginResult.GetCookie("session");
                if (string.IsNullOrEmpty(sessionCookie))
                {
                    _logger.LogError("Authorization failed.");
                    DelayUtils.SmallDelay();
                    return null;
                }
                UserSession = new LoginResponseModel
                {
                    Polito = politoCookie,
                    Session = sessionCookie
                };
                _logger.LogTrace(UserSession.GetLog());
                this.SaveSession(UserSession);

                return true;
            });
        }

        private void SaveSession(LoginResponseModel session)
        {
            File.WriteAllText(_sessionFilePath, JsonConvert.SerializeObject(session));
        }

        private LoginResponseModel LoadSession()
        {
            if(!File.Exists(_sessionFilePath))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<LoginResponseModel>(File.ReadAllText(_sessionFilePath));
        }
    }
}
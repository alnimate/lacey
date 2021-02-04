using System.IO;
using System.Threading.Tasks;
using Lacey.Alexa.Common.Shodan.Common;
using Lacey.Alexa.Common.Shodan.Extensions;
using Lacey.Alexa.Common.Shodan.Models;
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
                    AuthCookies = session;
                    _logger.LogTrace(AuthCookies.GetLog());
                    return true;
                }

                var loginGetRequest = AccountProvider.Login.LoginGet()
                    .SetDefault();
                var loginGet = await (await loginGetRequest.ExecuteUnparsedAsync()).ToLoginGet();
                AuthCookies = new AuthCookies
                {
                    CfdUid = loginGet.CfdUid,
                    Session = loginGet.Session
                };

                var loginRequest = AccountProvider.Login.Login(
                    Credentials.Username,
                    Credentials.Password,
                    loginGet.GrantType,
                    loginGet.Continue,
                    loginGet.CsrfToken)
                    .SetDefault()
                    .AddOrigin("https://account.shodan.io")
                    .AddSecFetchSite("same-origin")
                    .AddReferer("https://account.shodan.io/login")
                    .AddCookies(AuthCookies);
                var loginResult = await loginRequest.ExecuteUnparsedAsync();
                AuthCookies.Polito = loginResult.GetCookie("polito");
                AuthCookies.Session = loginResult.GetCookie("session");
                _logger.LogTrace(AuthCookies.GetLog());

                this.SaveSession(AuthCookies);

                return true;
            });
        }

        private void SaveSession(AuthCookies session)
        {
            File.WriteAllText(_sessionFilePath, JsonConvert.SerializeObject(session));
        }

        private AuthCookies LoadSession()
        {
            if(!File.Exists(_sessionFilePath))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<AuthCookies>(File.ReadAllText(_sessionFilePath));
        }
    }
}
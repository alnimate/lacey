using System.IO;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Core.Custom.Serializers;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Common;
using Lacey.Medusa.Surfer.Services.LikesRock.Const;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Serializers;
using Lacey.Medusa.Surfer.Services.LikesRock.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Services.Concrete
{
    public sealed class LrLoginService : LrService, ILrLoginService
    {
        private readonly string sessionFilePath;

        public LrLoginService(
            string sessionFilePath,
            ILogger logger, 
            ILrAuthProvider authProvider) : base(logger, authProvider)
        {
            this.sessionFilePath = sessionFilePath;
        }

        public async Task Login()
        {
            if (this.IsAuthenticated())
            {
                return;
            }

            await ProceedUtils.Proceed<bool?>(this.Logger, async () => {
                AuthCookies = new AuthCookies
                {
                    Username = this.UserSecrets.Username,
                    Password = this.UserSecrets.Password,
                    UserLang = UserLang,
                    Ga = "GA1.2.1583055054.1567053894",
                    Gid = "GA1.2.49410478.1567140764",
                    Gat = "1"
                };

                var bvbRequest = this.Lr.UserSignIn.SignInBvb(UserLang, ClientVersion)
                    .SetAuthCookies(AuthCookies)
                    .SetSerializer(new SignInBvbSerializer());
                var bvbResponse = await bvbRequest.ExecuteAsync();
                AuthCookies.Bvb = bvbResponse.Bvb;

                var sessionIdRequest = this.Lr.UserSignIn.SignInSessionId(UserLang, ClientVersion, "1")
                    .SetAuthCookies(AuthCookies)
                    .AddReferer($"https://likesrock.com/client-v2/user_signin.php?user_lang={UserLang}&client_version={ClientVersion}")
                    .SetSerializer(new WebFormsToJsonSerializer());

                var sessionId = (await sessionIdRequest.ExecuteUnparsedAsync()).GetCookie(PhpSessionId);
                AuthCookies.PhpSessionId = sessionId;
                this.Logger.LogTrace(AuthCookies.GetLog());

                var session = this.LoadSession();
                if (session != null)
                {
                    UserSession = session;
                    this.Logger.LogTrace(UserSession.GetLog());
                    return true;
                }

                var loginRequest = this.Lr.Ajax.Login(this.UserSecrets.Username, this.UserSecrets.Password)
                    .ClearExecInterceptors()
                    .AddUserAgent(HttpConst.UserAgent)
                    .AddCookies(AuthCookies)
                    .AddConnection("keep-alive")
                    .AddAccept("*/*")
                    .AddOrigin("https://likesrock.com")
                    .AddXRequestedWith("XMLHttpRequest")
                    .AddReferer($"https://likesrock.com/client-v2/user_signin.php?user_lang={UserLang}&client_version={ClientVersion}&security=1")
                    .AddAcceptLanguage("en-US,en;q=0.8");

                var loginInfo = await loginRequest.ExecuteAsync();
                if (loginInfo == null)
                {
                    this.Logger.LogError("Authorization failed.");
                    DelayUtils.LargeDelay();
                    return null;
                }

                this.Logger.LogTrace(loginInfo.GetLog());
                UserSession = new UserSession
                {
                    UserId = loginInfo.UserId,
                    UserName = loginInfo.UserName,
                    UserAccessToken = loginInfo.UserAccessToken
                };

                this.SaveSession(UserSession);

                return true;
            });
        }

        private void SaveSession(UserSession session)
        {
            File.WriteAllText(this.sessionFilePath, JsonConvert.SerializeObject(session));
        }

        private UserSession LoadSession()
        {
            if (!File.Exists(this.sessionFilePath))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserSession>(File.ReadAllText(this.sessionFilePath));
        }
    }
}
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Custom.Serializers;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Const;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Login;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers.Concrete;
using Lacey.Medusa.Surfer.Services.LikesRock.Serializers;
using Lacey.Medusa.Surfer.Services.LikesRock.Utils;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Common
{
    public abstract class LrService
    {
        protected const string UserLang = "ru";

        protected const string ClientVersion = "2.1.0.16";

        protected const string PhpSessionId = "PHPSESSID";

        protected readonly ILogger Logger;

        protected readonly ILrAuthProvider AuthProvider;

        protected readonly LrProvider Lr;

        protected readonly UserSecrets UserSecrets;

        protected readonly CommonSecrets CommonSecrets;

        protected static LoginResponseModel LoginInfo { get; private set; }

        protected static AuthCookies AuthCookies { get; private set; }

        private static readonly object Obj = new object();

        protected LrService(
            ILogger logger, 
            ILrAuthProvider authProvider)
        {
            Logger = logger;
            AuthProvider = authProvider;

            this.Lr = new LrProvider(
                new BaseClientService.Initializer
                {
                    Serializer = new WebFormsToJsonSerializer()
                });

            this.UserSecrets = this.AuthProvider.GetUserSecrets();
            this.CommonSecrets = this.AuthProvider.GetCommonSecrets();
        }

        public bool IsAuthenticated()
        {
            return LoginInfo != null;
        }

        public bool Login()
        {
            if (this.IsAuthenticated())
            {
                return true;
            }

            lock (Obj)
            {
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
                var bvbResponse = bvbRequest.ExecuteAsync().Result;
                AuthCookies.Bvb = bvbResponse.Bvb;

                var sessionIdRequest = this.Lr.UserSignIn.SignInSessionId(UserLang, ClientVersion, "1")
                    .SetAuthCookies(AuthCookies)
                    .AddReferer($"https://likesrock.com/client-v2/user_signin.php?user_lang={UserLang}&client_version={ClientVersion}")
                    .SetSerializer(new WebFormsToJsonSerializer());

                var sessionId = sessionIdRequest.ExecuteUnparsedAsync().Result.GetCookie(PhpSessionId);
                AuthCookies.PhpSessionId = sessionId;
                this.Logger.LogTrace(AuthCookies.GetLog());

                DelayUtils.Delay();
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

                LoginInfo = loginRequest.ExecuteAsync().Result;
                if (LoginInfo == null)
                {
                    return false;
                }

                this.Logger.LogTrace(LoginInfo.GetLog());
                return true;
            }
        }
    }
}
using System.Threading.Tasks;
using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Custom.Serializers;
using Lacey.Medusa.Common.Api.Custom.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Extensions;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Login;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers.Concrete;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Common
{
    public abstract class LikesRockService
    {
        protected const string UserLang = "ru";

        protected const string ClientVersion = "2.1.0.16";

        protected const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.110 Safari/537.36";

        protected const string PhpSessionId = "PHPSESSID";

        protected readonly ILogger Logger;

        protected readonly ILikesRockAuthProvider AuthProvider;

        protected readonly LikesRockProvider LikesRock;

        protected LoginResponseModel LoginInfo { get; private set; }

        protected LikesRockService(
            ILogger logger, 
            ILikesRockAuthProvider authProvider)
        {
            Logger = logger;
            AuthProvider = authProvider;

            this.LikesRock = new LikesRockProvider(
                new BaseClientService.Initializer
                {
                    Serializer = new WebFormsToJsonSerializer()
                });

            this.LikesRock.AddUserAgent(UserAgent);
        }

        protected bool IsAuthenticated()
        {
            return this.LoginInfo != null;
        }

        protected async Task Login()
        {
            if (this.IsAuthenticated())
            {
                return;
            }

            var bvbRequest = this.LikesRock.UserSignIn.SignIn(UserLang, ClientVersion, null);
            var bvbResponse = (await bvbRequest.ExecuteAsync()).GetSignInResponse();

            var credentials = this.AuthProvider.GetCredentials();
            var cookies = new AuthCookies
            {
                Username = credentials.Username,
                Password = credentials.Password,
                UserLang = UserLang,
                Bvb = bvbResponse.Bvb,
                Ga = "GA1.2.1583055054.1567053894",
                Gid = "GA1.2.49410478.1567140764",
                Gat = "1"
            };

            var sessionIdRequest = this.LikesRock.UserSignIn.SignIn(UserLang, ClientVersion, "1")
                .AddCookies(cookies);

            var sessionId = (await sessionIdRequest.ExecuteUnparsedAsync()).GetCookie(PhpSessionId);
            cookies.PhpSessionId = sessionId;

            var loginRequest = this.LikesRock.Ajax.Login(new LoginRequestModel
                {
                    Mode = "login",
                    Username = credentials.Username,
                    Password = credentials.Password
                })
                .AddCookies(cookies)
                .AddConnection("keep-alive")
                .AddAccept("*/*")
                .AddOrigin("https://likesrock.com")
                .AddXRequestedWith("XMLHttpRequest")
                .AddReferer($"https://likesrock.com/client-v2/user_signin.php?user_lang={UserLang}&client_version={ClientVersion}&security=1")
                .AddAcceptLanguage("en-US,en;q=0.8");

            this.LoginInfo = await loginRequest.ExecuteAsync();
        }
    }
}
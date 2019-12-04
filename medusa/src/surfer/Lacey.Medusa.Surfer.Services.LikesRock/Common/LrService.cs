using Lacey.Medusa.Common.Api.Base.Services;
using Lacey.Medusa.Common.Api.Core.Custom.Serializers;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers;
using Lacey.Medusa.Surfer.Services.LikesRock.Providers.Concrete;
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

        protected static UserSession UserSession { get; set; }

        protected static AuthCookies AuthCookies { get; set; }

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
            return UserSession != null;
        }
    }
}
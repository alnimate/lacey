using Facebook;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Facebook.Api.Services.Concrete
{
    public class FacebookProvider : IFacebookProvider
    {
        #region Fields/Constructors

        protected readonly FacebookClient Facebook;

        private readonly ILogger logger;

        public FacebookProvider(
            IFacebookAuthProvider facebookAuthProvider,
            ILogger<FacebookProvider> logger)
        {
            this.logger = logger;
            this.Facebook = new FacebookClient(facebookAuthProvider.GetAccessToken());
        }

        #endregion
    }
}
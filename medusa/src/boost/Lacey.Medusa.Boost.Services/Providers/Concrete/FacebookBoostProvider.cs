using System.Threading.Tasks;
using Lacey.Medusa.Facebook.Api.Services;
using Lacey.Medusa.Facebook.Api.Services.Concrete;
using Lacey.Medusa.Google.Api.Services;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Services.Providers.Concrete
{
    public sealed class FacebookBoostProvider : FacebookProvider, IFacebookBoostProvider
    {
        #region Properties/Constructors

        private readonly IGoogleProvider google;

        private readonly ILogger logger;

        public FacebookBoostProvider(
            IGoogleProvider google,
            IFacebookAuthProvider facebookAuthProvider, 
            ILogger<FacebookProvider> logger) 
            : base(facebookAuthProvider, logger)
        {
            this.google = google;
            this.logger = logger;
        }

        #endregion

        public async Task<object> SearchPeopleAsync(string query)
        {
            var result = await this.google.Search(query);

            if (result?.Items == null)
            {
                return null;
            }

            foreach (var item in result.Items)
            {
                if (!item.Link.Contains("Public-Figure"))
                {
                    continue;
                }
            }

            return result;
        }
    }
}
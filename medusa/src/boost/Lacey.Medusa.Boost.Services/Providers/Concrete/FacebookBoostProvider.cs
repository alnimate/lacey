using System.Linq;
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

        public async Task<string[]> SearchPeopleAsync(string query)
        {
            var facebookQuery = $"facebook {query} home";
            var result = await this.google.Search(facebookQuery);

            if (result?.Items == null)
            {
                return new string[0];
            }

            return result.Items.Select(i => i.Link).ToArray();
        }
    }
}
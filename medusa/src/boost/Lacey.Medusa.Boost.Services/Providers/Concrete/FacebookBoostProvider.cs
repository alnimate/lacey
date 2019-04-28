using System;
using System.Threading.Tasks;
using Lacey.Medusa.Facebook.Api.Services;
using Lacey.Medusa.Facebook.Api.Services.Concrete;
using Microsoft.Extensions.Logging;

namespace Lacey.Medusa.Boost.Services.Providers.Concrete
{
    public sealed class FacebookBoostProvider : FacebookProvider, IFacebookBoostProvider
    {
        #region Properties/Constructors

        private readonly ILogger logger;

        public FacebookBoostProvider(
            IFacebookAuthProvider facebookAuthProvider, 
            ILogger<FacebookProvider> logger) 
            : base(facebookAuthProvider, logger)
        {
            this.logger = logger;
        }

        #endregion

        public async Task<object> SearchPeopleAsync(string query)
        {
            object result;
            try
            {
                result = await this.Facebook.GetTaskAsync($"pages/search", new { q = query });
            }
            catch (Exception exc)
            {
                throw;
            }

            return result;
        }
    }
}
using System.Threading.Tasks;
using Lacey.Alexa.Common.Shodan.Common;
using Lacey.Alexa.Common.Shodan.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Common.Shodan.Services.Concrete
{
    public sealed class ShodanService : BaseService, IShodanService
    {
        public ShodanService(
            IShodanAuthProvider authProvider, 
            ILogger logger) : base(authProvider, logger)
        {
        }

        public async Task<string[]> GetHosts(string query)
        {
            if (!IsAuthenticated())
            {
                return new string[]{};
            }

            return new string[]{};
        }
    }
}
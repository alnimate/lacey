using System;
using System.Collections.Generic;
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

        private MetasploitProManager _metasploit;

        private readonly (string Username, string Password) _credentials;

        public MetasploitProvider(
            string metasploitUrl, 
            IMetasploitAuthProvider authProvider,
            ILogger logger)
        {
            _logger = logger;
            _session = new MetasploitSession($"{metasploitUrl}/api/");

            MetasploitAddress = new Uri(metasploitUrl).Host;
            _credentials = authProvider.GetCredentials();
        }

        #endregion

        #region IMetasploitProvider

        public string MetasploitAddress { get; }

        public async Task Login()
        {
            await _session.Login(_credentials.Username, _credentials.Password);
            _metasploit = new MetasploitProManager(_session);
        }

        public bool IsAuthenticated()
        {
            return _session.IsAuthenticated();
        }

        public async Task<Dictionary<string, object>> ExecuteModule(string moduleType, string moduleName, Dictionary<string, object> options)
        {
            return await Process.InContext(() => _metasploit.ExecuteModule(moduleType, moduleName, options), _logger);
        }

        public async Task<Dictionary<string, object>> ListJobs()
        {
            return await Process.InContext(() => _metasploit.ListJobs(), _logger);
        }

        public async Task<Dictionary<string, object>> StopJob(string jobId)
        {
            return await Process.InContext(() => _metasploit.StopJob(jobId), _logger);
        }

        public async Task<Dictionary<string, object>> ListSessions()
        {
            return await Process.InContext(() => _metasploit.ListSessions(), _logger);
        }

        public async Task<Dictionary<string, object>> WriteToSessionShell(string sessionId, string data)
        {
            return await Process.InContext(() => _metasploit.WriteToSessionShell(sessionId, data), _logger);
        }

        public async Task<Dictionary<string, object>> ReadSessionShell(string sessionId)
        {
            return await Process.InContext(() => _metasploit.ReadSessionShell(sessionId), _logger);
        }

        public async Task<Dictionary<string, object>> StopSession(string sessionId)
        {
            return await Process.InContext(() => _metasploit.StopSession(sessionId), _logger);
        }

        public async Task<Dictionary<string, object>> UpgradeShellToMeterpreter(string sessionId, string host, string port)
        {
            return await Process.InContext(() => _metasploit.UpgradeShellToMeterpreter(sessionId, host, port), _logger);
        }

        public async Task<Dictionary<string, object>> WriteToSessionMeterpreter(string sessionId, string data)
        {
            return await Process.InContext(() => _metasploit.WriteToSessionMeterpreter(sessionId, data), _logger);
        }

        public async Task<Dictionary<string, object>> ReadSessionMeterpreter(string sessionId)
        {
            return await Process.InContext(() => _metasploit.ReadSessionMeterpreter(sessionId), _logger);
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            _metasploit?.Dispose();
            _session.Dispose();
        }

        #endregion
    }
}
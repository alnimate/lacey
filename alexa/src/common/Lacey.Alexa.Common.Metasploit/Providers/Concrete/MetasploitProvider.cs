using System;
using System.Collections.Generic;
using System.Net;
using Lacey.Alexa.Common.Metasploit.Manager;
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

        public IPAddress MetasploitAddress { get; private set; }

        public Dictionary<string, object> ExecuteModule(string moduleType, string moduleName, Dictionary<string, object> options)
        {
            return _metasploit.ExecuteModule(moduleType, moduleName, options);
        }

        public Dictionary<string, object> ListJobs()
        {
            return _metasploit.ListJobs();
        }

        public Dictionary<string, object> StopJob(string jobId)
        {
            return _metasploit.StopJob(jobId);
        }

        public Dictionary<string, object> ListSessions()
        {
            return _metasploit.ListSessions();
        }

        public Dictionary<string, object> WriteToSessionShell(string sessionId, string data)
        {
            return _metasploit.WriteToSessionShell(sessionId, data);
        }

        public Dictionary<string, object> ReadSessionShell(string sessionId)
        {
            return _metasploit.ReadSessionShell(sessionId);
        }

        public Dictionary<string, object> StopSession(string sessionId)
        {
            return _metasploit.StopSession(sessionId);
        }

        public Dictionary<string, object> GetModuleCompatibleSessions(string moduleName)
        {
            return _metasploit.GetModuleCompatibleSessions(moduleName);
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
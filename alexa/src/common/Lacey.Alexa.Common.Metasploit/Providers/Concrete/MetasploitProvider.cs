using System.Collections.Generic;
using Lacey.Alexa.Common.Metasploit.Manager;
using Lacey.Alexa.Common.Metasploit.Models.Auth;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Common.Metasploit.Providers.Concrete
{
    public sealed class MetasploitProvider : IMetasploitProvider
    {
        private readonly string _metasploitUrl;

        private readonly IMetasploitAuthProvider _authProvider;

        private readonly ILogger _logger;

        private UserSecrets _credentials;

        public MetasploitProvider(
            string metasploitUrl, 
            IMetasploitAuthProvider authProvider, 
            ILogger logger)
        {
            _metasploitUrl = metasploitUrl;
            _authProvider = authProvider;
            _logger = logger;
            _credentials = _authProvider.GetUserSecrets();
        }

        public Dictionary<string, object> GetCoreModuleStats()
        {
            using var session = new MetasploitSession(_credentials.Username, _credentials.Password, $"{_metasploitUrl}/api/");
            using var manager = new MetasploitProManager(session);
            return manager.GetCoreModuleStats();
        }

        public Dictionary<string, object> GetCoreVersionInformation()
        {
            using var session = new MetasploitSession(_credentials.Username, _credentials.Password, $"{_metasploitUrl}/api/");
            using var manager = new MetasploitProManager(session);
            return manager.GetCoreVersionInformation();
        }
    }
}
using System.Collections.Generic;
using System.Net;

namespace Lacey.Alexa.Common.Metasploit.Providers
{
    public interface IMetasploitProvider
    {
        IPAddress MetasploitAddress { get; }

        Dictionary<string, object> ExecuteModule(string moduleType, string moduleName, Dictionary<string, object> options);

        Dictionary<string, object> ListJobs();

        Dictionary<string, object> StopJob(string jobId);

        Dictionary<string, object> ListSessions();

        Dictionary<string, object> WriteToSessionShell(string sessionId, string data);

        Dictionary<string, object> ReadSessionShell(string sessionId);

        Dictionary<string, object> StopSession(string sessionId);

        Dictionary<string, object> GetModuleCompatibleSessions(string moduleName);
    }
}
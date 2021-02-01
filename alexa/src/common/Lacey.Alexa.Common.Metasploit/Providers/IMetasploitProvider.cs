using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Lacey.Alexa.Common.Metasploit.Providers
{
    public interface IMetasploitProvider
    {
        IPAddress MetasploitAddress { get; }

        Task<Dictionary<string, object>> ExecuteModule(string moduleType, string moduleName, Dictionary<string, object> options);

        Task<Dictionary<string, object>> ListJobs();

        Task<Dictionary<string, object>> StopJob(string jobId);

        Task<Dictionary<string, object>> ListSessions();

        Task<Dictionary<string, object>> WriteToSessionShell(string sessionId, string data);

        Task<Dictionary<string, object>> ReadSessionShell(string sessionId);

        Task<Dictionary<string, object>> StopSession(string sessionId);

        Task<Dictionary<string, object>> GetModuleCompatibleSessions(string moduleName);
    }
}
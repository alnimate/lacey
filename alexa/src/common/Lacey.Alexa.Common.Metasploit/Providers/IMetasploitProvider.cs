using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lacey.Alexa.Common.Metasploit.Providers
{
    public interface IMetasploitProvider
    {
        string MetasploitAddress { get; }

        Task Login();

        bool IsAuthenticated();

        Task<Dictionary<string, object>> ExecuteModule(string moduleType, string moduleName,
            Dictionary<string, object> options);

        Task<Dictionary<string, object>> ListJobs();

        Task<Dictionary<string, object>> StopJob(string jobId);

        Task<Dictionary<string, object>> ListSessions();

        Task<Dictionary<string, object>> WriteToSessionShell(string sessionId, string data);

        Task<Dictionary<string, object>> ReadSessionShell(string sessionId);

        Task<Dictionary<string, object>> StopSession(string sessionId);

        Task<Dictionary<string, object>> UpgradeShellToMeterpreter(string sessionId, string host, string port);

        Task<Dictionary<string, object>> WriteToSessionMeterpreter(string sessionId, string data);

        Task<Dictionary<string, object>> ReadSessionMeterpreter(string sessionId);
    }
}
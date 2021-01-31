using System.Collections.Generic;

namespace Lacey.Alexa.Common.Metasploit.Models.Modules
{
    public sealed class MetasploitModule
    {
        public string Type { get; }

        public string Name { get; }

        public Dictionary<string, object> Options { get; }

        public MetasploitModule(string type, string name)
        {
            Type = type;
            Name = name;
            Options = new Dictionary<string, object>();
        }
    }
}
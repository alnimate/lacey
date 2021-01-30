using System.Collections.Generic;

namespace Lacey.Alexa.Common.Metasploit.Providers
{
    public interface IMetasploitProvider
    {
        Dictionary<string, object> GetCoreModuleStats();

        Dictionary<string, object> GetCoreVersionInformation();
    }
}
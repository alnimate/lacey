using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Alexa.Common.Metasploit.Extensions;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Common.Metasploit.Utils
{
    internal static class RequestUtils
    {
        public static async Task<Dictionary<string, object>> InContext(
            Func<Task<Dictionary<string, object>>> action,
            ILogger logger)
        {
            var result = await action();

            Console.WriteLine(result.AsColumns());
            
            return result;
        }
    }
}
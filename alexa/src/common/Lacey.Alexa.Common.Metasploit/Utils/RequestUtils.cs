using System;
using System.Collections.Generic;
using Lacey.Alexa.Common.Metasploit.Extensions;
using Microsoft.Extensions.Logging;

namespace Lacey.Alexa.Common.Metasploit.Utils
{
    internal static class RequestUtils
    {
        public static Dictionary<string, object> InContext(
            Func<Dictionary<string, object>> action,
            ILogger logger)
        {
            var result = action();

            Console.WriteLine(result.AsColumns());
            
            return result;
        }
    }
}
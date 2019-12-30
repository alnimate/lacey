using System;
using Newtonsoft.Json;

namespace Lacey.Medusa.Common.Core.Extensions
{
    public static class LogExtensions
    {
        public static string GetLog(this object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
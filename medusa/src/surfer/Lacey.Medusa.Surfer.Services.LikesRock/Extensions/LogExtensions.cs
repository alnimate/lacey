using System;
using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Extensions
{
    internal static class LogExtensions
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
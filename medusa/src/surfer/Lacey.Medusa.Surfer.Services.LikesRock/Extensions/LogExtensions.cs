using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Extensions
{
    internal static class LogExtensions
    {
        public static string GetLog(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
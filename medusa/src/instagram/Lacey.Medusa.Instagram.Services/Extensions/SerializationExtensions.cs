using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Lacey.Medusa.Instagram.Services.Extensions
{
    internal static class SerializationExtensions
    {
        public static T Deserialize<T>(
            this string obj)
        {
            return JsonConvert.DeserializeObject<T>(obj,
                new JsonSerializerSettings
                {
                    Error = delegate (object sender, ErrorEventArgs args)
                    {
                        args.ErrorContext.Handled = true;
                    }
                });
        }
    }
}
using Newtonsoft.Json;

namespace Lacey.Alexa.Common.Shodan.Models
{
    public sealed class AuthCookies
    {
        [JsonProperty("__cfduid")]
        public string CfdUid { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("polito")]
        public string Polito { get; set; }
    }
}
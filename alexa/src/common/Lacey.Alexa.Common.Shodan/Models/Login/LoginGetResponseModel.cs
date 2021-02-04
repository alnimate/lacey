using Newtonsoft.Json;

namespace Lacey.Alexa.Common.Shodan.Models.Login
{
    public sealed class LoginGetResponseModel
    {
        [JsonProperty("__cfduid")]
        public string CfdUid { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }

        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("continue")]
        public string Continue { get; set; }

        [JsonProperty("csrf_token")]
        public string CsrfToken { get; set; }
    }
}
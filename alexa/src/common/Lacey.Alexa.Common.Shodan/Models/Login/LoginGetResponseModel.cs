using Newtonsoft.Json;

namespace Lacey.Alexa.Common.Shodan.Models.Login
{
    public sealed class LoginGetResponseModel
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("continue")]
        public string Continue { get; set; }

        [JsonProperty("csrf_token")]
        public string CsrfToken { get; set; }
    }
}
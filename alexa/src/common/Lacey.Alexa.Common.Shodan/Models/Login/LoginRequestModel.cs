using Newtonsoft.Json;

namespace Lacey.Alexa.Common.Shodan.Models.Login
{
    public sealed class LoginRequestModel
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("continue")]
        public string Continue { get; set; }

        [JsonProperty("csrf_token")]
        public string CsrfToken { get; set; }
    }
}
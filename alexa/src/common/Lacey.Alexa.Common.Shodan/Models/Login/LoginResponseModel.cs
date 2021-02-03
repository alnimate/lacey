using Newtonsoft.Json;

namespace Lacey.Alexa.Common.Shodan.Models.Login
{
    public sealed class LoginResponseModel
    {
        [JsonProperty("polito")]
        public string Polito { get; set; }

        [JsonProperty("session")]
        public string Session { get; set; }
    }
}
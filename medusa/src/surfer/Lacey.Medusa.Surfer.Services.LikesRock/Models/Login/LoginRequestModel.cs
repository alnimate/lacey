using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.Login
{
    public sealed class LoginRequestModel
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("user_name")]
        public string Username { get; set; }

        [JsonProperty("user_pass")]
        public string Password { get; set; }
    }
}
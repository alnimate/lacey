using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth
{
    public sealed class AuthCookies
    {
        [JsonProperty("user_lang")]
        public string UserLang { get; set; }

        [JsonProperty("user_name")]
        public string Username { get; set; }

        [JsonProperty("user_pass")]
        public string Password { get; set; }

        [JsonProperty("BVB45629")]
        public string Bvb { get; set; }
    }
}
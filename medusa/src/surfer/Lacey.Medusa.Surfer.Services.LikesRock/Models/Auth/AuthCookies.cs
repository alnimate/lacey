using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth
{
    public sealed class AuthCookies
    {
        [JsonProperty("BVB45629")]
        public string Bvb { get; set; }

        [JsonProperty("user_name")]
        public string Username { get; set; }

        [JsonProperty("user_pass")]
        public string Password { get; set; }

        [JsonProperty("user_lang")]
        public string UserLang { get; set; }

        [JsonProperty("PHPSESSID")]
        public string PhpSessionId { get; set; }

        [JsonProperty("_ga")]
        public string Ga { get; set; }

        [JsonProperty("_gid")]
        public string Gid { get; set; }

        [JsonProperty("_gat")]
        public string Gat { get; set; }
    }
}
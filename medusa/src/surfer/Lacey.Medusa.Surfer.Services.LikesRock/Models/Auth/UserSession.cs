using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth
{
    public sealed class UserSession
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("user_email")]
        public string UserEmail { get; set; }

        [JsonProperty("user_access_token")]
        public string UserAccessToken { get; set; }
    }
}
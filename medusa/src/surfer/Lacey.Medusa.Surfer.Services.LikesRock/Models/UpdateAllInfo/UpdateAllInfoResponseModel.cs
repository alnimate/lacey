using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.UpdateAllInfo
{
    public sealed class UpdateAllInfoResponseModel
    {
        [JsonProperty("server_time")]
        public string ServerTime { get; set; }

        [JsonProperty("user_balance")]
        public string UserBalance { get; set; }

        [JsonProperty("user_msh_balance")]
        public string UserMshBalance { get; set; }

        [JsonProperty("user_events")]
        public string UserEvents { get; set; }

        [JsonProperty("user_social_events")]
        public string UserSocialEvents { get; set; }

        [JsonProperty("user_requests")]
        public string UserRequests { get; set; }

        [JsonProperty("user_messages")]
        public string UserMessages { get; set; }

        [JsonProperty("user_feed")]
        public string UserFeed { get; set; }
    }
}
using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.GetStats
{
    public sealed class GetStatsItemModel
    {
        [JsonProperty("social_network")]
        public string SocialNetwork { get; set; }

        [JsonProperty("social_account_id")]
        public string SocialAccountId { get; set; }

        [JsonProperty("first_use")]
        public string FirstUse { get; set; }

        [JsonProperty("last_use")]
        public string LastUse { get; set; }

        [JsonProperty("tasks")]
        public string Tasks { get; set; }

        [JsonProperty("total_earnings")]
        public string TotalEarnings { get; set; }
    }
}
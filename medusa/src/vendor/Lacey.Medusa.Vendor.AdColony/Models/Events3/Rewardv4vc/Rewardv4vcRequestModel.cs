using Newtonsoft.Json;

namespace Lacey.Medusa.Vendor.AdColony.Models.Events3.Rewardv4vc
{
    public sealed class Rewardv4VcRequestModel
    {
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("guid_key")]
        public string GuidKey { get; set; }

        [JsonProperty("replay")]
        public bool Replay { get; set; }

        [JsonProperty("reward")]
        public bool Reward { get; set; }

        [JsonProperty("reward_amount")]
        public int RewardAmount { get; set; }

        [JsonProperty("reward_name")]
        public string RewardName { get; set; }

        [JsonProperty("s_imp_count")]
        public int SImpCount { get; set; }

        [JsonProperty("s_time")]
        public double STime { get; set; }

        [JsonProperty("sid")]
        public string Sid { get; set; }

        [JsonProperty("zone_id")]
        public string ZoneId { get; set; }
    }
}
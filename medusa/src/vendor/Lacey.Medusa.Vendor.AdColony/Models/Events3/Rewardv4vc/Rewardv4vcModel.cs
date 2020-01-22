using Newtonsoft.Json;

namespace Lacey.Medusa.Vendor.AdColony.Models.Events3.Rewardv4vc
{
    public sealed class Rewardv4VcModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("v4vc_status")]
        public string V4VcStatus { get; set; }

        [JsonProperty("v4vc_callback")]
        public string V4VcCallback { get; set; }
    }
}
using Newtonsoft.Json;

namespace Lacey.Medusa.Vendor.AdColony.Models.Ads30.Configure
{
    public sealed class AppModel
    {
        [JsonProperty("macros")]
        public MacrosModel Macros { get; set; }
    }
}
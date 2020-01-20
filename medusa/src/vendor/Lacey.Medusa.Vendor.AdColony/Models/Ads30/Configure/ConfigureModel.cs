using Newtonsoft.Json;

namespace Lacey.Medusa.Vendor.AdColony.Models.Ads30.Configure
{
    public sealed class ConfigureModel
    {
        [JsonProperty("app")]
        public AppModel App { get; set; }
    }
}
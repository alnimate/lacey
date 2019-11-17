using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.GetStats
{
    public sealed class GetStatsResponseModel
    {
        [JsonProperty("statistics")]
        public GetStatsItemModel[] Items { get; set; }
    }
}
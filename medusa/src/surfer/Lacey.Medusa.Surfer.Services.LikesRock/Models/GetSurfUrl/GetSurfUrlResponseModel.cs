using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.GetSurfUrl
{
    public sealed class GetSurfUrlResponseModel
    {
        [JsonProperty("cmd")]
        public string Cmd { get; set; }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [JsonProperty("task_time")]
        public string TaskTime { get; set; }

        [JsonProperty("task_url")]
        public string TaskUrl { get; set; }
    }
}
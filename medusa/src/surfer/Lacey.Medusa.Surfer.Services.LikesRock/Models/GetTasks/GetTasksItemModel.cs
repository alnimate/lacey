using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.GetTasks
{
    public sealed class GetTasksItemModel
    {
        [JsonProperty("task_id")]
        public int TaskId { get; set; }

        [JsonProperty("task_time")]
        public int TaskTime { get; set; }

        [JsonProperty("task_url")]
        public string TaskUrl { get; set; }

        [JsonProperty("money")]
        public float Money { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
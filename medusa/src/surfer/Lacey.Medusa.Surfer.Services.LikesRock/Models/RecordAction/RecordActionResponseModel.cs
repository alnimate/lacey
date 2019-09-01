using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.RecordAction
{
    public sealed class RecordActionResponseModel
    {
        [JsonProperty("cmd")]
        public string Cmd { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("task_earned")]
        public string TaskEarned { get; set; }
    }
}
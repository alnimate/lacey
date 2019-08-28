using Newtonsoft.Json;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Models.Login
{
    public class LoginResponseModel
    {
        [JsonProperty("client_version")]
        public virtual string ClientVersion { get; set; }

        [JsonProperty("user_access_token")]
        public virtual string UserAccessToken { get; set; }

        [JsonProperty("user_balance")]
        public virtual string UserBalance { get; set; }

        [JsonProperty("user_email")]
        public virtual string UserEmail { get; set; }

        [JsonProperty("user_id")]
        public virtual string UserId { get; set; }

        [JsonProperty("user_lang")]
        public virtual string UserLang { get; set; }

        [JsonProperty("user_name")]
        public virtual string UserName { get; set; }

        [JsonProperty("user_subscr_days")]
        public virtual string UserSubscrDays { get; set; }

        [JsonProperty("user_subscr_status")]
        public virtual string UserSubscrStatus { get; set; }

        [JsonProperty("user_subscr_status_parsed")]
        public virtual string UserSubscrStatusParsed { get; set; }
    }
}
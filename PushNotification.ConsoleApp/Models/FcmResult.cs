using Newtonsoft.Json;

namespace PushNotification.ConsoleApp.Models
{
    public class FcmResult
    {
        [JsonProperty("message_id")]
        public string MessageId { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
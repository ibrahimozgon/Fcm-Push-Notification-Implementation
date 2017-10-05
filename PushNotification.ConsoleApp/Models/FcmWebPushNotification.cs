using Newtonsoft.Json;

namespace PushNotification.ConsoleApp.Models
{
    public class FcmWebPushNotification : IFcmPushNotificationBase
    {
        [JsonProperty("data")]
        public IPushNotificationMessageBase Message { get; set; }
        [JsonProperty("to")]
        public string Token { get; set; }
    }
}
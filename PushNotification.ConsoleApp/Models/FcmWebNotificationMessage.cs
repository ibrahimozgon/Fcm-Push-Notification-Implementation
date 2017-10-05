using Newtonsoft.Json;

namespace PushNotification.ConsoleApp.Models
{
    public class FcmWebNotificationMessage : IPushNotificationMessageBase
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("click_action")]
        public string ClickAction { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("badge")]
        public string Badge { get; set; }
    }
}
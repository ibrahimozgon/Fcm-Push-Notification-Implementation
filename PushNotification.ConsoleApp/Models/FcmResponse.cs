using System.Collections.Generic;
using Newtonsoft.Json;

namespace PushNotification.ConsoleApp.Models
{
    public class FcmResponse
    {
        [JsonProperty("multicast_id")]
        public long MulticastId { get; set; }
        [JsonProperty("success")]
        public int SuccessCount { get; set; }
        [JsonProperty("failure")]
        public int FailureCount { get; set; }
        [JsonProperty("canonical_ids")]
        public int CanonicalIds { get; set; }
        [JsonProperty("results")]
        public List<FcmResult> Results { get; set; }
        [JsonIgnore]
        public bool Success => SuccessCount > 0;
    }
}
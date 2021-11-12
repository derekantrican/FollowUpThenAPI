using System.Collections.Generic;
using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class SubscriberDetails
    {
        [JsonProperty("userid")]
        public string UserId { get; internal set; }

        [JsonProperty("plans")]
        public List<Plan> Plans { get; internal set; }

        [JsonProperty("limits")]
        public Limits Limits { get; internal set; }
    }
}

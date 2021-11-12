using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Billing
    {
        [JsonProperty("base_plan_id")]
        public string BasePlanId { get; internal set; }

        [JsonProperty("subscriber_details")]
        public SubscriberDetails SubscriberDetails { get; internal set; }
    }
}

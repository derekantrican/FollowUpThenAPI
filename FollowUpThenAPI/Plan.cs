using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Plan
    {
        [JsonProperty("plan_key")]
        public string PlanKey { get; internal set; }

        [JsonProperty("stripe_plan_id")]
        public string StripePlanId { get; internal set; }

        [JsonProperty("interval")]
        public string Interval { get; internal set; } //Todo: unknown data type (maybe int?)
    }
}

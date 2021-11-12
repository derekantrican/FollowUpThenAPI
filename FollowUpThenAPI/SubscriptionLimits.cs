using System.Collections.Generic;
using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class SubscriptionLimits
    {
        [JsonProperty("custom")]
        public bool Custom { get; internal set; }

        [JsonProperty("addon_plans")]
        public List<Plan> AddOnPlans { get; internal set; } //Todo: guessing on the data type

        [JsonProperty("limits")]
        public Limits Limits { get; internal set; }

        [JsonProperty("budget_cent")]
        public int BudgetCent { get; internal set; }
    }
}

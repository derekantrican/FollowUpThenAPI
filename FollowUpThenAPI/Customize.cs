using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Customize
    {
        [JsonProperty("followup_text")]
        public string FollowUpText { get; internal set; }

        [JsonProperty("custom_postpone_times")]
        public string CustomPostponeTimes { get; internal set; } //Todo: currently this is a comma-separated-list, but maybe this should be converted to a List<string> with a custom JsonConverter
    }
}

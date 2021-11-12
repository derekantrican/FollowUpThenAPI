using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class News
    {
        [JsonProperty("active_update")]
        public string ActiveUpdate { get; internal set; }

        [JsonProperty("update_shown_ct")]
        public int UpdateShownCt { get; internal set; } //Todo: unknown data type
    }
}

using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Mailbot
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("subdomain")]
        public string Subdomain { get; internal set; }

        [JsonProperty("stored_data")]
        public StoredData StoredData { get; internal set; }

        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("icon")]
        public string Icon { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }
    }
}

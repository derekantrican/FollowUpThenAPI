using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Attachment
    {
        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("content_type")]
        public string ContentType { get; internal set; }

        [JsonProperty("size")]
        public long Size { get; internal set; }

        [JsonProperty("token")]
        public string Token { get; internal set; }
    }
}

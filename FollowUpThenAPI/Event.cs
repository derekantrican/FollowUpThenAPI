using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace FollowUpThenAPI
{
    public class Event
    {
        [JsonProperty("eventid")]
        public long Id { get; internal set; }

        [JsonProperty("type")]
        public string Type { get; internal set; } //Todo: unknown data type (probably enum?)

        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedUTC { get; internal set; }

        [JsonProperty("data")]
        public JObject Data { get; internal set; }
    }
}

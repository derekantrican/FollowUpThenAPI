using System.Collections.Generic;
using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Limits
    {
        [JsonProperty("fut")]
        public int FollowUps { get; internal set; }

        [JsonProperty("active_futs")]
        public int ActiveFollowUps { get; internal set; }

        [JsonProperty("skills")]
        public List<string> Skills { get; internal set; }

        [JsonProperty("features")]
        public List<string> Features { get; internal set; } //Todo: unknown list type (maybe enum?)
    }
}

using System.Collections.Generic;
using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Headers
    {
        [JsonProperty("Message-ID")]
        public string MessageId { get; internal set; }

        [JsonProperty("References")]
        public List<string> References { get; internal set; }
    }
}

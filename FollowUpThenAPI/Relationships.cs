using System.Collections.Generic;
using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Relationships
    {
        [JsonProperty("user")]
        public User User { get; internal set; }

        [JsonProperty("people")]
        public List<Person> People { get; internal set; }

        [JsonProperty("mailbot")]
        public Mailbot Mailbot { get; internal set; }
    }
}

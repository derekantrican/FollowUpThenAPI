using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Person //Todo: should this be the same object as User?
    {
        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("email")]
        public string Email { get; internal set; }
    }
}

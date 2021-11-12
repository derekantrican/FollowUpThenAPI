using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class EmailAddress
    {
        [JsonProperty("email")]
        public string Email { get; internal set; }

        [JsonProperty("sender_validation")]
        public string SenderValidation { get; internal set; } //Todo: probably an enum (but I don't know the possible values)

        [JsonProperty("is_validated")]
        public bool IsValidated { get; internal set; }

        [JsonProperty("status")]
        public string Status { get; internal set; } //Todo: probably an enum (but I don't know the possible values)

        [JsonProperty("primary")]
        public bool Primary { get; internal set; }
    }
}

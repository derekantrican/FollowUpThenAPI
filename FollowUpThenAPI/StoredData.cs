using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class StoredData
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; internal set; }

        [JsonProperty("notifications")]
        public Notifications Notifications { get; internal set; }

        [JsonProperty("customize")]
        public Notifications Customize { get; internal set; }

        [JsonProperty("default_reminder_time")]
        public string DefaultReminderTime { get; internal set; } //Todo: maybe this should be converted to an int (to represent hour) or a DateTime

        [JsonProperty("futnews")]
        public News FutNews { get; internal set; }

        //There's also "wl" & "wl.active" but not sure if that's important
    }
}

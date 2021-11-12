using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Notifications
    {
        [JsonProperty("scheduling_confirmations")]
        public bool SchedulingConfirmation { get; internal set; }

        [JsonProperty("external_recipient_confirmation")]
        public int ExternalRecipientConfirmation { get; internal set; } //Todo: should this have been a bool? (looks like an int in the data)

        [JsonProperty("send_cancellation_confirmations")]
        public bool SendCancellationConfirmation { get; internal set; }

        [JsonProperty("daily_summary")]
        public bool DailySummary { get; internal set; }
    }
}

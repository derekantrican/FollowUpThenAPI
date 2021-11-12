using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Usage
    {
        //Todo: these are all strings that need to be converted to integers via a JsonConverter

        [JsonProperty("email_opens_self")]
        public int EmailOpensSelf { get; internal set; }

        [JsonProperty("gopher_task_created")]
        public int GopherTaskCreated { get; internal set; }

        [JsonProperty("mailbot_email_all")]
        public int MailbotEmailAll { get; internal set; }

        [JsonProperty("mailbot_email_sent")]
        public int MailbotEmailSent { get; internal set; }

        [JsonProperty("sent_email_self")]
        public int SentEmailSelf { get; internal set; }

        [JsonProperty("ActiveFuts")]
        public int ActiveFuts { get; internal set; }

        [JsonProperty("people")]
        public int People { get; internal set; }
    }
}

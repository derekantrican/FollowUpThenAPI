using System.Collections.Generic;
using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class Mail
    {
        [JsonProperty("to")]
        public List<string> To { get; internal set; }

        [JsonProperty("cc")]
        public List<string> CC { get; internal set; }

        [JsonProperty("bcc")]
        public List<string> BCC { get; internal set; }

        [JsonProperty("from")]
        public string From { get; internal set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; internal set; }

        [JsonProperty("subject")]
        public string Subject { get; internal set; }

        [JsonProperty("html")]
        public string Html { get; internal set; }

        [JsonProperty("text")]
        public string Text { get; internal set; }

        //[JsonProperty("forwarded_message")] //Todo: this is [] when "null", but an object {} when specified. So need a special converter
        //public Mail FowardedMessage { get; set; } //Todo: this is a limited version (looks like just From, To, & Subject) so maybe should be a separate class?

        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; internal set; } //Todo: this may not just be string

        [JsonProperty("headers")]
        public Headers Headers { get; internal set; }
    }
}

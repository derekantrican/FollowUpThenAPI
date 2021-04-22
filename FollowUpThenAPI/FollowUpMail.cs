using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FollowUpThenAPI
{
    public class FollowUpMail
    {
        [JsonProperty("to")]
        public List<string> To { get; set; }

        [JsonProperty("cc")]
        public List<string> CC { get; set; }

        [JsonProperty("bcc")]
        public List<string> BCC { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
        //[JsonProperty("forwarded_message")]
        //public FollowUpMail FowardedMessage { get; set; } //Todo: will need a converter because empty is [] and non-empty is an object

        [JsonProperty("attachments")]
        public List<string> Attachments { get; set; } //Todo: this may not just be string
        //public object Headers //Todo
    }
}

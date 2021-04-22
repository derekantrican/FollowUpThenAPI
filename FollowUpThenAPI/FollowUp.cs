using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FollowUpThenAPI
{
    public class FollowUp
    {
        [JsonProperty("id")]
        public long Id { get; private set; }

        [JsonProperty("hash")]
        public string Hash { get; private set; }

        [JsonProperty("trigger_url")]
        public string TriggerUrl { get; private set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedUTC { get; private set; }

        [JsonProperty("invisible")]
        public bool Invisible { get; private set; } //Todo: read-only?

        [JsonProperty("trigger_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? TriggerTimeUTC { get; private set; }

        [JsonProperty("trigger_timeformat")]
        public string TriggerTimeFormat { get; private set; } //Todo:read-only and the Reschedule method should be used?

        [JsonProperty("completed")]
        public bool Completed { get; private set; }

        [JsonProperty("completed_on")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? CompletedOnUtc { get; private set; }

        [JsonProperty("reference_email")]
        public FollowUpMail ReferenceEmail { get; private set; }

        [JsonProperty("command")]
        public string Command { get; private set; } //Todo: read-only and have the Reschedule method used?
        //public object Relationships { get; set; } //Todo

        public FollowUp Complete(/*Todo: parameters?*/) //Todo: is Archive different?
        {
            throw new NotImplementedException(); //Todo
        }

        public void /*Todo: check return type*/ FollowUpNow(/*Todo: parameters?*/)
        {
            throw new NotImplementedException(); //Todo
        }

        public void /*Todo: check return type*/ Reschedule(/*Todo: parameters?*/)
        {
            throw new NotImplementedException(); //Todo
        }

        public void /*Todo: check return type*/ Delete(/*Todo: parameters?*/)
        {
            throw new NotImplementedException(); //Todo
        }

        public void /*Todo: check return type*/ ChangeDeliveryAddress(/*Todo: parameters?*/)
        {
            throw new NotImplementedException(); //Todo
        }

        public void /*Todo: check return type*/ Download(/*Todo: parameters?*/)
        {
            throw new NotImplementedException(); //Todo
        }

        public void /*Todo: check return type*/ AddAttachment(/*Todo: parameters?*/)
        {
            throw new NotImplementedException(); //Todo
        }

        public void /*Todo: check return type*/ GetHistory(/*Todo: parameters?*/)
        {
            throw new NotImplementedException(); //Todo
        }
    }
}

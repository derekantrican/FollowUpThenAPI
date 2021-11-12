using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace FollowUpThenAPI
{
    public class FollowUp //Also known as a "Task" but I think I'll keep the name "FollowUp"
    {
        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("hash")]
        public string Hash { get; internal set; }

        [JsonProperty("trigger_url")]
        public string TriggerUrl { get; internal set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedUTC { get; internal set; }

        [JsonProperty("invisible")]
        public bool Invisible { get; internal set; }

        [JsonProperty("trigger_time")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? TriggerTimeUTC { get; internal set; }

        [JsonProperty("trigger_timeformat")]
        public string TriggerTimeFormat { get; internal set; }

        [JsonProperty("completed")]
        public bool Completed { get; internal set; }

        [JsonProperty("completed_on")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? CompletedOnUtc { get; internal set; }

        [JsonProperty("reference_email")]
        public Mail ReferenceEmail { get; internal set; }

        [JsonProperty("command")]
        public string Command { get; internal set; }

        [JsonProperty("relationships")]
        public Relationships Relationships { get; internal set; }

        [JsonProperty("search_keys")]
        public List<string> SearchKeys { get; internal set; }

        public void Complete() //Todo: is Archive different?
        {
            this.Completed = true;

            Requests.Put($"tasks/{Id}", new JObject(
                                    new JProperty("task", new JObject(
                                        new JProperty("completed", true)))));
        }

        public void FollowUpNow()
        {
            Requests.Get(TriggerUrl);
        }

        /// <summary>
        /// Reschedules the follow up. Use the typical format (eg "7pm" or "nov21")
        /// </summary>
        /// <param name="command"></param>
        public void Reschedule(string command)
        {
            this.Command = command.EndsWith("@followupthen.com") || command.EndsWith("@fut.io") ? command : $"{command}@followupthen.com";
            this.TriggerTimeFormat = Command.Split('@')[0];

            FollowUp updatedObject = Requests.Put($"tasks/{Id}", new JObject(
                                                        new JProperty("task", new JObject(
                                                            new JProperty("id", Id),
                                                            new JProperty("command", Command),
                                                            new JProperty("trigger_timeformat", TriggerTimeFormat)))))["task"].ToObject<FollowUp>();

            Utilities.CopyPropertiesToObject(this, updatedObject);
        }

        public void Delete()
        {
            Requests.Delete($"tasks/{Id}");
        }

        public void AddRecipient(string recipientEmailAddress, EmailSendType emailSendType)
        {
            switch (emailSendType)
            {
                case EmailSendType.To:
                    ReferenceEmail.To.Add(recipientEmailAddress);
                    break;
                case EmailSendType.CC:
                    ReferenceEmail.CC.Add(recipientEmailAddress);
                    break;
                case EmailSendType.BCC:
                    ReferenceEmail.BCC.Add(recipientEmailAddress);
                    break;
            }

            Requests.Put($"tasks/{Id}", new JObject(
                new JProperty("task", new JObject(
                    new JProperty("id", Id),
                    new JProperty("reference_email", JObject.FromObject(ReferenceEmail))))));
        }

        public void ChangeDeliveryAddress(string newDeliveryAddress)
        {
            ReferenceEmail.From = newDeliveryAddress;

            Requests.Put($"tasks/{Id}", new JObject(
                new JProperty("task", new JObject(
                    new JProperty("id", Id),
                    new JProperty("reference_email", JObject.FromObject(ReferenceEmail))))));
        }

        public void AddAttachment(string localFilePath)
        {
            Requests.Upload($"tasks/{Id}/attachments", localFilePath);
        }

        public List<Event> GetHistory()
        {
            return Requests.Get($"tasks/{Id}/events")["events"].ToObject<List<Event>>();
        }

        public override string ToString()
        {
            return $"{TriggerTimeFormat}: {ReferenceEmail.Subject}";
        }
    }
}

using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace FollowUpThenAPI
{
    public class FollowUpThenClient
    {
        private readonly string email;

        public FollowUpThenClient(string email, string token)
        {
            this.email = email;
            Requests.Token = token;
        }

        /// <summary>
        /// Retrieves a list of FollowUps. NOTE: this retrieves a "shallow" version of each FollowUp. Use "GetFollowUp" to retrieve the full details.
        /// </summary>
        /// <param name="page">The starting page</param>
        /// <param name="perPage">The number of items per page</param>
        /// <param name="orderBy"></param>
        /// <param name="orderDir"></param>
        /// <param name="status"></param>
        /// <returns>A list of FollowUps</returns>
        public List<FollowUp> ListFollowUps(int page = 0, int perPage = 30, string orderBy = "due", string orderDir = "asc", string status = "open")
        {
            JObject result = Requests.Get($"tasks?order_by={orderBy}&order_dir={orderDir}&page={page}&per_page={perPage}&status={status}");
            string json = result.ToString(Newtonsoft.Json.Formatting.Indented);
            return result["tasks"].ToObject<List<FollowUp>>();
        }

        public FollowUp GetFollowUp(long id)
        {
            JObject result = Requests.Get($"tasks/{id}");
            return result["task"].ToObject<FollowUp>();
        }

        /// <summary>
        /// Creates a followup
        /// </summary>
        /// <param name="command">The time-formatted string (eg "4pm") for when the followup should occur</param>
        /// <param name="subject">The subject of the followup</param>
        /// <param name="body">The body of the followup</param>
        /// <returns>The created FollowUp</returns>
        public FollowUp CreateFollowUp(string command, string subject, string body = "" /*Todo: also include people*/)
        {
            command = command.EndsWith("@followupthen.com") || command.EndsWith("@fut.io") ? command : $"{command}@followupthen.com";
            JObject result = Requests.Post("tasks", new JObject(new JProperty("webhook", true),
                                                                new JProperty("task", new JObject(
                                                                    new JProperty("command", command),
                                                                    new JProperty("reference_email", JObject.FromObject(new Mail
                                                                    {
                                                                        From = email,
                                                                        To = new List<string>
                                                                        {
                                                                            command
                                                                        },
                                                                        Subject = subject,
                                                                        Html = body,
                                                                    }))/*people*/))));

            return result["task"].ToObject<FollowUp>();
        }
    }
}

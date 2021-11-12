using System.IO;
using System.Collections.Generic;
using FollowUpThenAPI;
using Newtonsoft.Json.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject credentials = JObject.Parse(File.ReadAllText("credentials.json"));
            FollowUpThenClient client = new FollowUpThenClient(credentials["token"].Value<string>());
            //client.CreateFollowUp("4pm", "This is a test subject");

            //List<FollowUp> followUps = client.ListFollowUps();

            FollowUp fut = client.GetFollowUp(38647315);

            //fut.Reschedule("1700");
            //followUps.Find(f => f.Id == "36654597").Complete();
        }
    }
}

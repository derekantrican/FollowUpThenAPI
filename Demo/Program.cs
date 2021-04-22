using System;
using System.Collections.Generic;
using System.IO;
using FollowUpThenAPI;
using Newtonsoft.Json.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject credentials = JObject.Parse(File.ReadAllText("credentials.json"));
            FollowUpThenClient client = new FollowUpThenClient(credentials["email"].Value<string>(), credentials["token"].Value<string>());
            client.CreateFollowUp("4pm", "This is a test subject");
            //List<FollowUp> followUps = client.ListFollowUps();
        }
    }
}

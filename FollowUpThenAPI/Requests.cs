using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace FollowUpThenAPI
{
    internal static class Requests
    {
        const string baseUrl = "https://api.mailbots.com/api/v1/";

        internal static JObject Get(string endpoint, string token)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl + endpoint);
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {token}");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                return JObject.Parse(reader.ReadToEnd());
            }
        }

        internal static JObject Post(string endpoint, string token, JObject payload)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl + endpoint);
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {token}");
            request.ContentType = "application/json";
            request.Method = "POST";

            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(payload.ToString());
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                return JObject.Parse(reader.ReadToEnd());
            }
        }
    }
}

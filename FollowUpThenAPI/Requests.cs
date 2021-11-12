using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FollowUpThenAPI
{
    internal static class Requests
    {
        const string baseUrl = "https://api.mailbots.com/api/v1/";
        internal static string Token { get; set; }

        internal static JObject Get(string endpoint)
        {
            return MakeRequest(endpoint, "GET");
        }

        internal static JObject Post(string endpoint, JObject payload)
        {
            return MakeRequest(endpoint, "POST", payload);
        }

        internal static JObject Put(string endpoint, JObject payload)
        {
            return MakeRequest(endpoint, "PUT", payload);
        }

        internal static JObject Delete(string endpoint)
        {
            return MakeRequest(endpoint, "DELETE");
        }

        internal static void Upload(string endpoint, string localFilePath)
        {
            string url = endpoint.Contains("http") ? endpoint : baseUrl + endpoint;

            string boundary = $"---------------------------{DateTime.Now.Ticks.ToString("x")}";
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes($"\r\n--{boundary}\r\n");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token}");
            request.ContentType = $"multipart/form-data; boundary={boundary}";
            request.Method = "POST";
            request.KeepAlive = true;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(boundarybytes, 0, boundarybytes.Length);

                string header = $"Content-Disposition: form-data; name=\"{Path.GetFileName(localFilePath)}\"; filename=\"{localFilePath}\"\r\n\r\n";
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                requestStream.Write(headerbytes, 0, headerbytes.Length);

                using (FileStream fileStream = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        requestStream.Write(buffer, 0, bytesRead);
                    }
                }

                byte[] trailer = System.Text.Encoding.ASCII.GetBytes($"\r\n--{boundary}--\r\n");
                requestStream.Write(trailer, 0, trailer.Length);
            }

            HttpStatusCode statusCode;
            string response;
            using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                statusCode = webResponse.StatusCode;
                response = reader.ReadToEnd();
            }
        }

        private static JObject MakeRequest(string endpoint, string method, JObject payload = null)
        {
            string url = endpoint.Contains("http") ? endpoint : baseUrl + endpoint;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {Token}");
            request.ContentType = "application/json";
            request.Method = method;

            if (payload != null)
            {
                using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(payload.ToString());
                }
            }

            HttpStatusCode statusCode;
            string response;
            using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
            {
                statusCode = webResponse.StatusCode;
                response = reader.ReadToEnd();
            }

            JToken jsonResponse = JToken.Parse(response);
            if (statusCode == HttpStatusCode.OK && (jsonResponse.IsEmpty() || jsonResponse["status"].Value<string>() == "success"))
            {
                return jsonResponse as JObject;
            }
            else
            {
                Exception ex = new Exception("FUT API did not return success. See exception.Data for API response");
                ex.Data["statusCode"] = statusCode;
                ex.Data["response"] = response;
                ex.Data["jsonResponse"] = jsonResponse?.ToString(Formatting.Indented);
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Shared.Helpers
{
    public static class WebRequestHelper
    {
        public static string CallGetRequest(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.Proxy = null;
            request.UserAgent = "GitHubExplorer";

            string responseString = string.Empty;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}

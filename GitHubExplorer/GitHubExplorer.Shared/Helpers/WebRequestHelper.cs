﻿using System.IO;
using System.Net;

namespace GitHubExplorer.Shared.Helpers
{
    public static class WebRequestHelper
    {
        public static string CallGetRequest(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.Proxy = null;
                request.UserAgent = "GitHubExplorer";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (WebException wex)
            {
                if(((HttpWebResponse)wex.Response).StatusCode == HttpStatusCode.NotFound)
                {
                    return ((HttpWebResponse)wex.Response).StatusCode.ToString();
                }
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Chess.Atomic.Crawling.WebClasses
{
    public class AtomicWebClient
    {
        protected WebClient webClient = new WebClient();

        protected string url = string.Empty;



        public void SetParams(params Tuple<string, string>[] queryParams)
        {
            foreach (var p in queryParams)
            {
                if (webClient.QueryString.AllKeys.Contains(p.Item1))
                    webClient.QueryString[p.Item1] = p.Item2;
                else
                    webClient.QueryString.Add(p.Item1, p.Item2);
            }
        }

        public void ClearParams()
        {
            webClient.QueryString.Clear();
        }

        public string GetResponse()
        {
            string response = string.Empty;

            using (webClient)
            {
                try
                {
                    response = webClient.DownloadString(url);
                }
                catch (Exception exc)
                {

                }
            }

            return response;
        }
    }
}
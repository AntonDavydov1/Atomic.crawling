using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

namespace Chess.Atomic.Crawling.WebClasses
{
    public class AtomicWebClient
    {
        protected WebClient webClient = new WebClient();

        protected string url = string.Empty;

        private Stopwatch sw = new Stopwatch();

        bool bigTimeout = false;

        public AtomicWebClient()
        {
            sw.Start();
        }

        public void SetUrl(string url)
        {
            this.url = url;
        }

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

        private void CheckInterval()
        {
            Thread.Sleep(1000);

            if (bigTimeout)
            {
                Thread.Sleep(60000);
                sw.Restart();
                bigTimeout = false;
            }
        }

        public string GetResponse()
        {
            CheckInterval();

            string response = string.Empty;

            using (webClient)
            {
                WebException ex = new WebException();
                
                try
                {
                    response = webClient.DownloadString(url);
                }
                catch (WebException e)
                {
                    if ((int)((HttpWebResponse)e.Response).StatusCode == 429)     // Too many requests
                    {
                        bigTimeout = true;

                        GetResponse();
                    }
                    else
                    { }

                }
                    catch (Exception exc)
                {}
            }

            return response;
        }
    }
}
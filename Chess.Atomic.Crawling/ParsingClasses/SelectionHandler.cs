using Chess.Atomic.Crawling.WebClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.ParsingClasses
{
    public class SelectionHandler
    {
        int currWeek = 0;
        int currPage;

        AtomicWebClientPlayer webClient;

        AtomicParser parser;

        public void Init(AtomicWebClientPlayer client, AtomicParser parser)
        {
            webClient = client;
            this.parser = parser;
        }

        public bool InitDateInterval()
        {
            if (webClient.init)
            {
                webClient.SetForFirstGame();
                string res = webClient.GetResponse();

                DateTime start = parser.GetDateTimeFromFirst(res);
                start.AddDays(2);

                return true;
            }

            return false;
            
        }

        /// <returns>
        /// true - exists next interval
        /// false - end
        /// </returns>
        public bool NextDateInterval()
        {
            currWeek += 2;

            webClient.SetParams(Tuple.Create("dateMin", currWeek.ToString() + "w"), Tuple.Create("dateMax", (currWeek + 2).ToString() + "w"));

            return true;
        }

        public bool InitPage()
        {
            currPage = 1;
            webClient.SetPage(currPage);

            return true;
        }

        public bool NextPage()
        {
            return true;
        }
    }
}
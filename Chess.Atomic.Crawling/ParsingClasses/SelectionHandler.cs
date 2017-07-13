using Chess.Atomic.Crawling.WebClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Chess.Atomic.Crawling.ParsingClasses
{
    public class SelectionHandler
    {
        int currDay = 0;
        int interval = 1;

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
            //if (webClient.init)
            //{
            //    webClient.SetForFirstGame();

            //    string bruto = string.Empty;

            //    bool succeed = false;

            //    do
            //    {
            //        try
            //        {
            //            bruto = webClient.GetResponse();
            //            succeed = true;
            //        }
            //        catch (Exception exc)
            //        {
            //            Thread.Sleep(1000);
            //        }
            //    }
            //    while (!succeed);


            //    if (string.IsNullOrEmpty(bruto)) return false;

            //    currDay = parser.GetCountDaysFromFirst(bruto);

            //    if (currDay <= 0) return false;

            currDay = 180; // manually, because lichess returns list of games in unsorted order.

            interval = 14; // 2 weeks

            return true;
            //}

            //return false;

        }

        /// <returns>
        /// true - exists next interval
        /// false - end
        /// </returns>
        public bool NextDateInterval()
        {
            InitPage();

            if (currDay == 0) return false;

            int count = 0;

            do
            {
                string dateMax = (currDay - interval) > 0 ? (currDay - interval).ToString() : string.Empty;

                webClient.SetParams(Tuple.Create("dateMin", currDay.ToString() + "d"), Tuple.Create("dateMax", dateMax + "d"));

                string bruto = string.Empty;

                bool succeed = false;

                do
                {
                    try
                    {
                        bruto = webClient.GetResponse();
                        succeed = true;
                    }
                    catch (Exception exc)
                    {
                        Thread.Sleep(1000);
                    }
                }
                while (!succeed);


                count = parser.GetCountGamesFromBruto(ref bruto);

                if (count > 350) interval = (int)Math.Floor((double)((interval * 351) / count));

                if (interval < 1) interval = 1;
            }
            while (count > 350);

            currDay -= interval; // движемся от n до 0
            if (currDay < 0) currDay = 0;

            return true;
        }

        public bool InitPage()
        {
            currPage = 1;

            return true;
        }

        public bool NextPage()
        {
            if (currPage > 39) return false;

            webClient.SetPage(currPage++);

            return true;
        }
    }
}
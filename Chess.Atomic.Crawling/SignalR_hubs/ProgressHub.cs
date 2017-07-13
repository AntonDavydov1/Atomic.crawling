using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;
using Chess.Atomic.Crawling.ParsingClasses;

namespace Chess.Atomic.Crawling.SignalR_hubs
{
    public class ProgressHub : Hub
    {
        public void Crawling(string playerName)
        {
            //GlobalHost.ConnectionManager.

                //Clients.All.Update(progress, playerName);
            Chess.Atomic.Crawling.ParsingClasses.Crawling.Instance.ParseOnePlayer(playerName);
        }
    }
}
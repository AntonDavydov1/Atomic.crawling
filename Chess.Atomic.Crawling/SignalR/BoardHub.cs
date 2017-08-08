using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;
using Chess.Atomic.Crawling.ParsingClasses;
using System.Web.Helpers;
using Chess.Atomic.Crawling.Models;

namespace Chess.Atomic.Crawling.SignalR_hubs
{
    public class BoardHub : Hub
    {
        //public void Send()
        //{
        //    var data = new { curHint = GameData.Instance.curHint, curState = GameData.Instance.curState };

        //    var jsondata = Json.Encode(data);

        //    Clients.All.UpdateBoardYo(jsondata);

        //}
    }
}
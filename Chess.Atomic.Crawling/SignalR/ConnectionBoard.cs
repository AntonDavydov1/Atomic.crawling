using Chess.Atomic.Crawling.Models;
using Chess.Atomic.Crawling.SignalR_hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Chess.Atomic.Crawling.SignalR
{
    public class ConnectionBoard
    {
        // Singleton instance
        private readonly static ConnectionBoard _instance = new ConnectionBoard(GlobalHost.ConnectionManager.GetHubContext<BoardHub>());

        public static ConnectionBoard Instance
        {
            get
            {
                return _instance;
            }
        }

        private IHubContext _context;

        private ConnectionBoard(IHubContext context)
        {
            _context = context;
        }

        public void UpdateBoard()
        {
            var data = new { curHint = GameData.Instance.curHint, curState = GameData.Instance.curState };

            //var jsondata = Json.Encode(data);

            _context.Clients.All.UpdateBoardYo(data);
            
        }
    }
}
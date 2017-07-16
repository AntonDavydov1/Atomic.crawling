using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class GameShort
    {
        public string id { get; set; }

        public string white { get; set; }

        public string black { get; set; }

        public int whiteRaiting { get; set; }

        public int blackRaiting { get; set; }

        public GameStatus status { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class AtomicGameInfo
    {
        public string id { get; set; }

        public string white { get; set; }

        public string black { get; set; }

        public string moves { get; set; }

        public GameStatus status { get; set; }
    }

    public enum GameStatus
    {
        Unknown = 0,
        WhiteVictorious,
        BlackVictorious,
        Draw
    }
}
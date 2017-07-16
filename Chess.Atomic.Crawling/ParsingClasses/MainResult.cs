using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.ParsingClasses
{
    public class MainResult
    {
        public int currentPage { get; set; }
        public int maxPerPage { get; set; }
        public GameResult[] currentPageResults { get; set; }
        public int nbResults { get; set; }
        public int previousPage { get; set; }
        public int nextPage { get; set; }
        public int nbPages { get; set; }
    }

    public class GameResult
    {
        public string id { get; set; }
        public bool rated { get; set; }
        public string variant { get; set; }
        public string speed { get; set; }
        public string perf { get; set; }
        public int createdAt { get; set; }
        public int turns { get; set; }
        public string status { get; set; }
        public Clock clock { get; set; }
        public Players players { get; set; }
        public string moves { get; set; }
        public string winner { get; set; }
        public string url { get; set; }
    }

    public class Clock
    {
        public int initial { get; set; }
        public int increment { get; set; }
        public int totalTime { get; set; }
    }

    public class Players
    {
        public Player white { get; set; }
        public Player black { get; set; } 
    }

    public class Player
    {
        public string userId { get; set; }
        public int raiting { get; set; }
    }
}
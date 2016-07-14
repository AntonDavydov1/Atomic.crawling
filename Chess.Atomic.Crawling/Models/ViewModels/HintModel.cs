using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models.ViewModels
{
    public class HintModel
    {
        public Dictionary<string, int> hints = new Dictionary<string, int>();

        public string currMoves = string.Empty;

        public string winner { get; set; }
    }
}
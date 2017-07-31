using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public sealed class GameData
    {
        private GameData()
        {
            curState = new int[64];

            curHint = new Move();            
        }

        private static readonly GameData instance = new GameData();

        public static GameData Instance
        {
            get { return instance; }
        }

        public string curMoves { get; set; }

        public string winner { get; set; }

        public int[] curState;

        public Move curHint;

        public bool whiteToPlay;
    }
}
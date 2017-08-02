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
            curState = new int[64] {
                1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                2, 2, 2, 2, 2, 2, 2, 2,
                2, 2, 2, 2, 2, 2, 2, 2,
            };

            curHint = new Move();

            prevPlayedGames = new List<AtomicGameInfoOld>();
        }

        private static readonly GameData instance = new GameData();

        public static GameData Instance
        {
            get { return instance; }
        }

        public List<AtomicGameInfoOld> prevPlayedGames;

        public string curMoves { get; set; }

        public string winner { get; set; }

        public int[] curState;

        public Move curHint;

        public bool whiteToPlay;

        public bool reset { get; set; }

        public void Reset()
        {
            curState = new int[64] {
                1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0,
                2, 2, 2, 2, 2, 2, 2, 2,
                2, 2, 2, 2, 2, 2, 2, 2,
            };

            curMoves = String.Empty;

            winner = String.Empty;

            curHint.moveFrom.x = 0;
            curHint.moveFrom.y = 0;
            curHint.moveTo.x = 0;
            curHint.moveTo.y = 0;

            whiteToPlay = true;

            reset = false;
        }

        public void Init()
        {
            

            foreach (var g in prevPlayedGames)
            { }
        }
    }
}
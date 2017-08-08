using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class HintsEngine
    {
        private static HintsEngine instance = new HintsEngine();

        private HintsEngine()
        {
            
 
        }

        public static HintsEngine Instance
        {
            get
            {
                return instance;
            }
        }

        private string[] AdditionalHints = new string[] { 

            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "b1c3f8b4" + "d4b5g8h6" + "g2g4xxOO" + "b5a7f6f5" + "h2h4e6e5" + "f2f3f5g4" + "f1h3h6g4" + "xxOOd8f6" + "c3e4b4d2" + "e4g5h7h5" + "g5e6f6e6" + "f3f4d7d5" + "h3g4c8h3",
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "b1c3f8b4" + "d4b5g8h6" + "h2h3e6e5",
            "g1f3f7f6" + "e2e3e7e6" + "f3d4c7c6" + "b1c3f8b4" + "d4b5g8h6" + "b5c7e8f8",


            // tough line
            "g1f3f7f6" + "f3d4g8h6" + "e2e3h6g4" + "f2f4b7b5" + "d4f5e7e5" + "f5g7h7h5" + "c2c3d7d5" + "d1b3a7a5" + "f1b5b8d7" + "d2d3c7c6" + "h2h3g4f2" + "b3b7c8b7",
            "g1f3f7f6" + "f3d4g8h6" + "e2e3h6g4" + "f2f4b7b5" + "d4f5e7e5" + "f5g7h7h5" + "c2c3d7d5" + "d1b3a7a5" + "f1b5b8d7" + "d2d3c7c6" + "h2h3g4f2" + "b1a3a8b8",
            //"g1f3f7f6" + "f3d4g8h6" + "e2e3h6g4" + "f2f4b7b5" + "d4f5e7e5" + "f5g7h7h5" + "c2c3d7d5" + "d1b3a7a5" + "f1b5b8d7" + "d2d3c7c6" + "h2h3g4f2" + "",
            
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "e2e3d7d5" + "b1c3a7a6" + "b2b3b7b5" + "c3e4d5e4" + "d2d4c8g4" + "f2f3g4f5" + "e3e4e7e6" + "",
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "e2e3d7d5" + "d2d4b8a6" + "a2a3e7e5" + "c1d2a8b8" + "f1e2g7g6",
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "e2e3d7d5" + "f1b5c7c6",
            
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "e2e4d7d5" + "b1a3a7a6" + "d2d4e7e5" + "c2c3h7h5" + "e4d5c8f5" + "f1b5c7c6" + "b5c4f8d6" + "c4f7e8f8" + "c1g5f5c2" + "d1d2e5e4" + "d2c1f6g5" + "g2g3d8f6" + "f2f3h5h4" + "a3c4h4g3" + "c1g5f6g5",
            //"g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "e2e4d7d5" + "b1a3a7a6" + "d2d4e7e5" + "c2c3h7h5" + "e4d5c8f5" + "f1b5c7c6" + "b5c4f8d6" + "c4f7e8f8" + "c1g5f5c2" + "d1d2e5d4"
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "d2d4d7d5" + "e2e4b8a6" + "a2a3e7e5",
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "d2d3d7d5" + "b1c3b8a6" + "c3b5c8g4" + "f2f3a6b4" + "c1h6g7h6" + "b5c7b4c2" + "a1c1a8c8" + "c1c7c8c7" + "f3g4f8h6" + "e2e3e8d7",
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "d2d3d7d5" + "b1c3b8a6" + "c3b5c8g4" + "f2f3a6b4" + "c1h6g7h6" + "b5c7b4c2" + "a1c1a8c8" + "f3g4c8c2" + "c1c2e7e6" + "b2b4f8d6" + "g2g3e8d7" + "f1h3f6f5" + "e2e4h8c8",
            "g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "b1c3c7c6" + "d2d4d7d5" + "e2e4b8a6" + "c3b5c8g4" + "f2f3a6b4" + "b5c7d8c7" + "c1g5b4c2",
            //"g1f3f7f6" + "f3d4g8h6" + "d4f5h6f5" + "b1c3c7c6" + "d2d4d7d5" + "e2e4b8a6" + "c3b5c8g4" + "f2f3a6b4" + "b5c7d8c7" + "c1h6",

            "g1f3f7f6" + "b1c3g8h6" + "c3d5e7e6" + "h2h3e6d5" + "f3d4d7d5" + "e2e3f8b4" + "c2c3b4c3" + "d1b3c8f5" + "f1a6f5b1" + "a2a3b8a6" + "b3b4d8d6",

            "g1f3f7f6" + "b1a3g8h6" + "f3e5f6e5" + "h2h3e7e5" + "e2e3d8f6" + "f2f3f6g6",
            "g1f3f7f6" + "b1a3g8h6" + "f3e5f6e5" + "h2h3e7e5" + "g2g3f8b4" + "c2c3xxOO",

            "g1f3f7f6" + "f3e5f6e5" + "d2d4d7d5",


            "g1f3f7f6" + "d2d4e7e6" + "e2e4d7d5" + "b1a3b7b5",

            



            "g1h3h7h6" + "e2e3e7e6" + "b1c3f8b4" + "f1b5c7c6" + "d1h5g7g6" + "h5e5d8h4" + "g2g3h4f4" + "f2f3f4e5",
            "g1h3h7h6" + "e2e3e7e6" + "b1c3f8b4" + "d1h5g7g6" + "f1b5c7c6" + "h5e5d8h4" + "g2g3h4f4" + "f2f3f4e5",
            
            "g1h3h7h6" + "e2e3e7e6" + "b1a3d8h4" + "g2g3h4g4" + "f2f3g4b4" + "c2c3b4b2" + "",
            
            "g1h3h7h6" + "e2e3e7e6" + "h3f4b8c6" + "d1h5g7g6" + "h5h4d8h4" + "f1b5g8f6" + "f4e6f8g7" + "b1c3xxOO",
            "g1h3h7h6" + "e2e3e7e6" + "h3f4b8c6" + "d1h5g7g6" + "h5h4d8h4" + "f4d5g8f6",
            "g1h3h7h6" + "e2e3e7e6" + "h3f4b8c6" + "f4h5f8b4" + "c2c3c6d4" + "e3d4d8h4",
            "g1h3h7h6" + "e2e3e7e6" + "h3f4b8c6" + "f4h5f8b4" + "c2c3c6d4" + "d1f3d4f3",

            "g1h3h7h6"  + "d2d4e7e6" + "e2e4b8a6" + "d1h5g7g6" + "h5b5c7c6",
            




            "d2d4b8a6" + "b1c3e7e6" + "g1f3d8h4" + "f3h4g8f6" + "e2e4a6b4" + "d1h5f6h5" + "c3b5a7a6" + "a2a3b4c2" + "b5c7a8c8",
            "d2d4b8a6" + "b1c3e7e6" + "g1f3d8h4" + "g2g3h4g4" + "b2b4f8b4",
            "d2d4b8a6" + "a2a3d7d5" + "g1h3f7f6",


            "b1c3e7e6" + "e2e3f8b4" + "d1h5g7g6" + "h5f3f7f5",
            "b1c3e7e6" + "g1f3d8f6" + "c3e4f6d4" + "f3d4g8f6" + "e2e4f6g4" + "f2f4h7h5" + "f1b5c7c6" + "b2b4g4f2" + "d1e2f2d3" + "e1f1c6b5" + "b4b5f8b4" + "c2c3b4c5" + "c1a3d7d6" + "a3c5b8d7" + "a1b1b7b6" + "c3c4d7c5" + "h2h4e6e5" + "g2g4g7g6" + "f4f5g6f5" + "h1g1d3f4" + "e2d1f4e2" + "g1g2f7f5" + "d2d4f5f4" + "d4c5e2c3" + "f1f2", // ok
            "b1c3e7e6" + "g1f3d8f6" + "c3e4f6d4" + "f3d4g8f6" + "e2e4f6g4" + "f2f4h7h5" + "f1b5c7c6" + "b2b4g4f2" + "d1e2f2d3" + "e1f1c6b5" + "",
            "b1c3e7e6" + "g1f3d8f6" + "c3e4f6d4" + "f3d4g8f6" + "f2f3",




            "e2e3e7e6" + "g1f3d8f6" + "f1d3f8b4" + "c2c3b4c3" + "d1a4b7b5" + "a4d4d7d6" + "e1d1e8d8" + "f3g5c7c5" + "g5f7c5d4" + "b1c3c8b7" + "e3e4g7g5" + "d2d3b8d7" + "f2f4h8f8" + "h1f1d7c5" + "f4g5f8f2" + "f1f2c5b3" + "c1g5d8e8" + "a1b1a8c8" + "d1e1b3c1" + "a2a4d6d5" + "g5e7e8d7" + "a4a5c1d3" + "e7c5d5e4" + "",
            //"e2e3e7e6" + "g1f3d8f6" + "f1d3f8b4" + "c2c3b4c3" + "d1a4b7b5" + "a4d4d7d6" + "e1d1e8d8" + "f3g5c7c5" + "g5f7c5d4" + "b1c3c8b7" + "e3e4g7g5" + "d2d4",

            "e2e3e7e6" + "d1h5g7g6" + "g1f3d8h4" + "g2g3h4b4" + "c2c3f7f6"

        };

        public HintModel FindHints(string prevMoves, string winner)
        {
            HintModel hints = new HintModel();

            hints.currMoves = prevMoves;

            hints.winner = winner;

            string nextMove = string.Empty;

            int startIndex = prevMoves.Length;

            string hint = AdditionalHints.FirstOrDefault(h => h.StartsWith(prevMoves));

            if (!String.IsNullOrEmpty(hint) && hint.Length >= startIndex + 4)
            {
                nextMove = hint.Substring(startIndex, 4);

                if (hints.hints.ContainsKey(nextMove)) ++hints.hints[nextMove];
                else hints.hints.Add(nextMove, 1);
            }

            //if (hints.hints.Count == 0)
            //{
            //    IEnumerable<AtomicGameInfoOld> games = GameData.Instance.prevPlayedGames.Where(g => g.moves.StartsWith(prevMoves));

            //    foreach (var g in games)
            //    {
            //        if (g.moves.Length >= startIndex + 4)
            //        {
            //            nextMove = g.moves.Substring(startIndex, 4);

            //            if (hints.hints.ContainsKey(nextMove)) ++hints.hints[nextMove];
            //            else hints.hints.Add(nextMove, 1);
            //        }
            //    }
            //}
            

            return hints;
        }

    }
}
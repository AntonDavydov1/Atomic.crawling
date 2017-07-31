using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class HintsEngine
    {
        public static HintModel FindHints(string moves, string winner)
        {
            HintModel hints = new HintModel();

            hints.currMoves = moves;

            hints.winner = winner;

            using (var context = new ChessAtomicCrawlingContextOld())
            {
                GameStatus res = string.Equals(winner, "white") ? GameStatus.WhiteVictorious : GameStatus.BlackVictorious;

                var games = from b in context.AtomicGameInfoOlds
                            where b.status == res && b.moves.StartsWith(moves)
                            select b;

                string nextMove = string.Empty;

                int startIndex = moves.Length;

                foreach (var g in games)
                {
                    if (g.moves.Length >= startIndex + 4)
                    {
                        nextMove = g.moves.Substring(startIndex, 4);

                        if (hints.hints.ContainsKey(nextMove)) ++hints.hints[nextMove];
                        else hints.hints.Add(nextMove, 1);
                    }
                }
            }
            return hints;
        }

    }
}
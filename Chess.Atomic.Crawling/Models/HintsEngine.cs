﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class HintsEngine
    {
        public static HintModel FindHints(string prevMoves, string winner)
        {
            HintModel hints = new HintModel();

            hints.currMoves = prevMoves;

            hints.winner = winner;

            IEnumerable<AtomicGameInfoOld> games = GameData.Instance.prevPlayedGames.Where(g => g.moves.StartsWith(prevMoves));

            string nextMove = string.Empty;

            int startIndex = prevMoves.Length;

            foreach (var g in games)
            {
                if (g.moves.Length >= startIndex + 4)
                {
                    nextMove = g.moves.Substring(startIndex, 4);

                    if (hints.hints.ContainsKey(nextMove)) ++hints.hints[nextMove];
                    else hints.hints.Add(nextMove, 1);
                }
            }

            return hints;
        }

    }
}
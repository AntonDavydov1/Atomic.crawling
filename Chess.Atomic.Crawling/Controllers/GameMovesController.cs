using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chess.Atomic.Crawling.Models;
using Chess.Atomic.Crawling.ParsingClasses;
using System.Threading;
using Chess.Atomic.Crawling.Models.ViewModels;
using System.Diagnostics;
using Chess.Atomic.Crawling.WebClasses;

namespace Chess.Atomic.Crawling.Controllers
{
    public class GameMovesController : Controller
    {
        //public ActionResult Hint([Bind(Include = "moves,winner")]string moves, string winner)
        //{
        //    HintModel hints = new HintModel();

        //    hints.currMoves = moves;

        //    hints.winner = winner;

        //    using (var context = new ChessAtomicCrawlingContext())
        //    {
        //        GameStatus res = string.Equals(winner, "white") ? GameStatus.WhiteVictorious : GameStatus.BlackVictorious; 

        //        var games = from b in context.AtomicGameInfo
        //                    where b.status == res && b.moves.StartsWith(moves)
        //                    select b;

        //        string nextMove = string.Empty;

        //        int startIndex = moves.Length;

        //        foreach (var g in games)
        //        {
        //            if (g.moves.Length >= startIndex + 4)
        //            {
        //                nextMove = g.moves.Substring(startIndex, 4);

        //                if (hints.hints.ContainsKey(nextMove)) ++hints.hints[nextMove];
        //                else hints.hints.Add(nextMove, 1);
        //            }
        //        }
        //    }


        //    return View("~/Views/GameMoves/Hints.cshtml", hints); 
        //}

        public ActionResult HintOld([Bind(Include = "moves,winner")]string moves, string winner)
        {
            HintModel hints = new HintModel();

            hints.currMoves = moves;

            hints.winner = winner;

            using (var context = new ChessAtomicCrawlingContext())
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


            return View("~/Views/GameMoves/Hintsold.cshtml", hints);
        }
    }
}

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
using System.Threading.Tasks;

namespace Chess.Atomic.Crawling.Controllers
{
    public class GameMovesController : Controller
    {

        public ActionResult Index()
        {
            return View(); 
        }



        
        public async Task<EmptyResult> PlayWhite()
        {
            GameData.Instance.curMoves = string.Empty;
            GameData.Instance.winner = "white";
            GameData.Instance.whiteToPlay = true;

            await MainEngine.Go();

            return new EmptyResult();
        }

        
        public async Task<EmptyResult> PlayBlack()
        {
            GameData.Instance.curMoves = string.Empty;
            GameData.Instance.winner = "black";
            GameData.Instance.whiteToPlay = true;

            await MainEngine.Go();

            return new EmptyResult();
        }



        [HttpPost]
        public JsonResult ShowBoard()
        {



            var jsondata = GameData.Instance;
            
            var res = Json(jsondata, JsonRequestBehavior.AllowGet);

            return res;
        }


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
            HintModel hints = HintsEngine.FindHints(moves, winner);


            return View("~/Views/GameMoves/Hintsold.cshtml", hints);
        }

            }
}

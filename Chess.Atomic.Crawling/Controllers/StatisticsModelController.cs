using Chess.Atomic.Crawling.Models;
using Chess.Atomic.Crawling.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chess.Atomic.Crawling.Controllers
{
    public class StatisticsModelController : Controller
    {
        private ChessAtomicCrawlingContext db = new ChessAtomicCrawlingContext();

        public ActionResult Index()
        {
            var players = db.Players.ToList();

            List<StatisticsModel> stats = new List<StatisticsModel>();

            int count = 0;

            foreach (var pl in players)
            {
                count = (from game in db.AtomicGameInfo
                         where string.Equals(game.black, pl.name) || string.Equals(game.white, pl.name)
                         select game)
                        .Count();
                    
                   // db.AtomicGameInfo.Select(a => string.Equals(a.black, pl.name)).ToList().Count;

                stats.Add(new StatisticsModel { name = pl.name, raiting = pl.raiting, localCount = count });
            }



            return View(stats);
        }
    }
}

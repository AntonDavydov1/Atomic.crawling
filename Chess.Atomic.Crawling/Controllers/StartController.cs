using Chess.Atomic.Crawling.Models.ViewModels;
using Chess.Atomic.Crawling.ParsingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Chess.Atomic.Crawling.Controllers
{
    public class StartController : Controller
    {
        private PlayersController plController = new PlayersController();

        // GET: Start
        public ActionResult Index()
        {
            AtomicParser parser = new AtomicParser();

            var players = plController.GetPlayers();

            List<StatisticsModel> stats = new List<StatisticsModel>();

            int count = 0;

            foreach (var pl in players)
            {
                count = (from game in plController.db.AtomicGameInfo
                         where string.Equals(game.black, pl.name) || string.Equals(game.white, pl.name)
                         select game)
                        .Count();

                StatisticsModel sm = new StatisticsModel { name = pl.name, raiting = pl.raiting, lichessCount = (pl.raiting > 0) ? parser.GetPlayerLichessCount(pl.name) : 0, localCount = count };

                sm.percentage = (sm.lichessCount > 0) ? (float)Math.Round((((double)sm.localCount / sm.lichessCount) * 100), 2) : 100;

                stats.Add(sm);
            }



            return View(stats);
        }
    }
}
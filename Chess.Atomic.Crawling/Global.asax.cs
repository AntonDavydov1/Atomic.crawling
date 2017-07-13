using Chess.Atomic.Crawling.Models;
using Chess.Atomic.Crawling.ParsingClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Chess.Atomic.Crawling
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<Chess.Atomic.Crawling.Models.ChessAtomicCrawlingContext>(new DropCreateDatabaseIfModelChanges<Chess.Atomic.Crawling.Models.ChessAtomicCrawlingContext>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Chess.Atomic.Crawling.Controllers.PlayersController plController = new Controllers.PlayersController();


            //try
            //{
            //    plController.db.Updates.Add(new UpdatesInfo { playerName = "time", lastUpdate = DateTime.Now });
            //    plController.db.SaveChanges();
            //}
            //catch(Exception exc){}



            //var allPlayers = (from pl in plController.db.Players
            //               select pl.name)
            //               .ToList();

            //foreach (var pl in allPlayers)
            //{
            //    UpdatesInfo player = plController.db.Updates.First(a => a.playerName == pl);

            //    if (player == null) continue;

            //    if ((DateTime.Now - player.lastUpdate).Days >= 1)
            //    {
 
            //    }
            //}

            //try
            //{

            //    DateTime now = DateTime.Now;

            //    var plNeedsToCrawling = (from upd in plController.db.Updates
            //                             where (now - upd.lastUpdate).Days > 1
            //                             select upd.playerName)
            //                            .ToList();

            //}
            //catch (Exception ec)
            //{ }
            //var updates = plController.db.Updates.ToList();



            //var date = updates[0].lastUpdate;

            //AtomicParser parser = new AtomicParser();

            //var players = plController.GetPlayers();

            //foreach (var player in players)
            //{
            //    player.raiting = parser.GetPlayerRaiting(player.name);

            //    plController.Edit(player);
            //}
        }
    }
}

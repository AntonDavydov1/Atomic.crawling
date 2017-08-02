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

            using(var context = new ChessAtomicCrawlingContextOld())
            {
                try
                {
                    GameData.Instance.prevPlayedGames = context.AtomicGameInfoOlds.ToList();
                }
                catch (System.Data.DataException e)
                { 
                }

                List<AtomicGameInfoOld> sameMoves = null;

                foreach (var g in GameData.Instance.prevPlayedGames)
                {
                    sameMoves = GameData.Instance.prevPlayedGames.Where(game => String.Equals(game.moves, g.moves)).ToList();

                    sameMoves.Remove(g);
                    if (sameMoves.Count > 0) context.AtomicGameInfoOlds.RemoveRange(sameMoves);
                    
                }

                context.SaveChanges();
            }
        }
    }
}

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

            //Chess.Atomic.Crawling.Controllers.PlayersController pl = new Controllers.PlayersController();

            //string[] players = new string[] { "tipau", "krasss", "penguingim1", "Fyuxs", "Mabrook",
            //    "pashpash", "hUdSonZiNho", "Ardavan74", "anthonypower1", "Ghostknight",
            //    "FlyAway", "Rhex", "moustruito", "vampire_rodent", "MagoAtomico", 
            //    "Gannet", "lord-zero", "victorvi", "kreedz", "jananth1", 
            //    "OrigamiCaptainFaN", "Chacarron", "nnnnnnn7", "FixedPoint", "JimmeeX", 
            //    "Frmiranda137", "slowwinning", "Sikstufff", "Shampanskoe_Vino", "Pasili", 
            //    "blitzbullet" };
        }
    }
}

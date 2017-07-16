using Chess.Atomic.Crawling.Models;
using Chess.Atomic.Crawling.ParsingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Chess.Atomic.Crawling.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }

        public string ParsePlayerGameShorts(string playerId)
        {

            Chess.Atomic.Crawling.ParsingClasses.Crawling.ParsePlayerGameShorts(playerId);



            return "Ok";
        }
    }

}
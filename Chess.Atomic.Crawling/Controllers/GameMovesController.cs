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

namespace Chess.Atomic.Crawling.Controllers
{
    public class GameMovesController : Controller
    {
        

        public ActionResult Create([Bind(Include = "id,t1,t2,t3,t4,t5,t6,t7,t8,t9,t10,t11,t12,t13,t14,tplus")] AtomicGameInfo atomicGameInfo)
        {
            if (ModelState.IsValid)
            {
                //db.AtomicGameInfo.Add(atomicGameInfo);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(atomicGameInfo);
        }

        public ActionResult Crawling([Bind(Include = "playerId")]string playerId)
        {
            if (ModelState.IsValid)
            {
                string url = String.Format("https://en.lichess.org/@/{0}/search", playerId);

                var webClient = new WebClient();
                webClient.QueryString.Add("perf", "14");
                webClient.QueryString.Add("page", "1");

                string listOfGames = string.Empty;
                AtomicParser atomic = new AtomicParser();
                int countGames = 0;

                Queue<string> gamesId = new Queue<string>();
                var webClient2 = new WebClient();

                //Queue<string> failedDownloads = new Queue<string>();
                //int failsInSequence = 0;

                //Queue<string> failedPages = new Queue<string>();
                int failedPagesInSequence = 0;

                using (webClient)
                {
                    // получаем список игр в результатах поиска (сейчас только чтобы получить количество игр)
                    listOfGames = webClient.DownloadString(url);
                    countGames = atomic.ParseFirstPage(ref listOfGames);

                    int currPage = 1;



                    while (atomic.GetCountGames() < countGames)
                    {
                        bool keepParse = true;

                        try
                        {
                            // получаем список игр в результатах поиска ( теперь будем извлекать id )
                            listOfGames = webClient.DownloadString(url);

                            // извлекаем id в gamesId
                            atomic.ParseListOfGames(listOfGames, ref gamesId);

                            // если в ответе не было списка игр, то завершаем парсинг
                            if (gamesId.Count == 0) break;

                            while (gamesId.Count > 0)
                            {
                                using (webClient2)
                                {
                                    string currGameId = gamesId.Dequeue();

                                    string gameInfo = string.Empty;

                                    // загружаем инфу о текущей игре
                                    try
                                    {
                                        gameInfo = webClient2.DownloadString("https://en.lichess.org/" + currGameId);
                                        // парсим ответ, полученный в предыдущем запросе
                                        keepParse = atomic.ParseGame(currGameId, gameInfo);
                                        //failsInSequence = 0;
                                    }
                                    catch (Exception exc)
                                    {
                                        //failedDownloads.Enqueue(currGameId);
                                        Thread.Sleep(2000);
                                        //++failsInSequence;

                                        gamesId.Enqueue(currGameId);

                                    }
                                }
                            }
                        }
                        catch (Exception exc)
                        {
                            //failedPages.Enqueue(currPage.ToString());

                            --currPage;

                            Thread.Sleep(2000);
                            ++failedPagesInSequence;

                            if (failedPagesInSequence > 5) keepParse = false;
                        }

                        // увеличиваем страницу
                        ++currPage;
                        // теперь будем получать список игр со следующей страницы
                        webClient.QueryString["page"] = currPage.ToString();

                        // temporarily restriction one page for checkout
                        if (!keepParse) break;
                    }
                }


                //return View("~/Views/Home/Index.cshtml", atomic.gameElements.Take(10));
            }

            return View("~/Views/Home/Index.cshtml", "ModelState not valid");
        }


        public ActionResult Hint([Bind(Include = "moves,winner")]string moves, string winner)
        {
            HintModel hints = new HintModel();

            hints.currMoves = moves;

            hints.winner = winner;

            using (var context = new ChessAtomicCrawlingContext())
            {
                GameStatus res = string.Equals(winner, "white") ? GameStatus.WhiteVictorious : GameStatus.BlackVictorious; 

                var games = from b in context.AtomicGameInfo
                            where b.status == res && b.moves.StartsWith(moves)
                            select b;

                string nextMove = string.Empty;

                int startIndex = moves.Length;

                foreach (var g in games)
                {
                    nextMove = g.moves.Substring(startIndex, 4);

                    if (hints.hints.ContainsKey(nextMove)) ++hints.hints[nextMove];
                    else hints.hints.Add(nextMove, 1);
                }
            }


            return View("~/Views/GameMoves/Hints.cshtml", hints); 
        }

        //// GET: GameMoves
        //public ActionResult Index()
        //{
        //    return View(db.GameMoves.ToList());
        //}

        //// GET: GameMoves/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GameMoves gameMoves = db.GameMoves.Find(id);
        //    if (gameMoves == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(gameMoves);
        //}

        //// GET: GameMoves/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

 

        //// GET: GameMoves/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GameMoves gameMoves = db.GameMoves.Find(id);
        //    if (gameMoves == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(gameMoves);
        //}

        //// POST: GameMoves/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,t1,t2,t3,t4,t5,t6,t7,t8,t9,t10,t11,t12,t13,t14,tplus")] GameMoves gameMoves)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(gameMoves).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(gameMoves);
        //}

        //// GET: GameMoves/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    GameMoves gameMoves = db.GameMoves.Find(id);
        //    if (gameMoves == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(gameMoves);
        //}

        //// POST: GameMoves/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    GameMoves gameMoves = db.GameMoves.Find(id);
        //    db.GameMoves.Remove(gameMoves);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

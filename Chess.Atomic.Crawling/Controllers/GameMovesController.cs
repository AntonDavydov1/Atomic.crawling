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
        WathcModel watch = new WathcModel();
        

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
                string[] players = new string[] { /*"tipau", "krasss", "penguingim1", "Fyuxs", "Mabrook",
                "pashpash", "hUdSonZiNho", "Ardavan74", "anthonypower1", "Ghostknight",
                "FlyAway", "Rhex", "moustruito", "Ardavan74", "vampire_rodent", "MagoAtomico",
                "Gannet", "lord-zero", "victorvi", "kreedz", "jananth1",
                */
                    
                    
                   // "OrigamiCaptainFaN", "Chacarron", "nnnnnnn7", "FixedPoint", "JimmeeX", "Frmiranda137", "slowwinning", "Sikstufff", "Shampanskoe_Vino", "Pasili"



                    /*"blitzbullet"*/ "Run_it" //, "MathNetaji" //, "Nonpareil", "Caustic", "j0e", "mob123", "Deathmaster", "LANGSDORF
                
                
                // ukimix", "Sanhedrin", "Unihedron", "Godislove", "Kleerkast", "brd123", "TheLlamaLord", "AC8", "yoavjm", "ivigorsev61"


//51	 SpaWnn	2261	10
//52	 pablito1970	2255	54
//53	 prostoprosto	2253	38
//54	 dreamsmorning48	2252	5
//55	 isaacly	2242	52
//56	 xurde96	2241	53
//57	 chudoyudo	2240	63
//58	 miniond	2233	35
//59	 raph22	2232	3
//60	 FierceNapkin	2231	29


//61	 eshshennawy92	2220	14
//62	 Vuduland	2214	7
//63	 Shahmatti	2214	45
//64	 MessyAnswer	2210	29
//65	 danjyo	2209	88
//66	 brahm	2207	57
//67	 helbert	2206	24
//68	 younameit	2201	5
//69	 Project_2200	2200	37
//70	 g0ofi	2193	52


//71	 High_Voltage	2191	42
//72	 theatomicpatzer	2191	36
//73	 Solidworks	2189	18
//74	 xuanet	2189	20
//75	 Duubik	2186	80
//76	 dsotr	2184	1
//77	 lodvaluedfunction	2184	41
//78	 breizhion	2171	22
//79	 javor07	2171	23
//80	 KillingField	2166	17


//81	 Kristal	2165	11
//82	 Chess_player_1234	2165	78
//83	 Bogdan__2001	2161	26
//84	 strategoo	2160	59
//85	 tankbox1	2160	3
//86	 littleplotkin	2153	3
//87	 barakuda-2	2151	11
//88	 hata	2150	35
//89	 stiFfenBishoP	2150	
//90	 Kasique-8	2149	29


//91	                 "scottecs", "kamikazee", "Hyp3rspeed", "DaeneryStormborn", "Italianmachine97", "wowa1963", "Sorsi", "seanysean", "sansanich97", "ChessWhiz"
                
                };

                watch.totalTime.Start();

                for (int i = 0; i < players.Length; ++i)
                    ParseOnePlayer(players[i]);

               // Thread.Sleep(1000);

                watch.totalTime.Stop();

                watch.ConvertResults();

                return View(watch.data);
            }

            return View("~/Views/Home/Index.cshtml", "ModelState not valid");
        }

        private void ParseOnePlayer(string playerId)
        {


            string listOfGames = string.Empty;
            AtomicParser atomic = new AtomicParser();
            //int countGames = 0;

            Queue<string> gamesId = new Queue<string>();
            var webClient2 = new WebClient();

            //Queue<string> failedDownloads = new Queue<string>();
            //int failsInSequence = 0;

            //Queue<string> failedPages = new Queue<string>();
            int failedPagesInSequence = 0;

            int failedMonthInSequence = 0;


            atomic.webClient.Init(playerId);

            // получаем список игр одного конкретного игрока в результатах поиска (сейчас только чтобы получить количество игр)
            //listOfGames = webClient.GetResponse();



            //countGames = atomic.ParseFirstPage(ref listOfGames);




            //int currWeek = 0;

            atomic.webClient.SetParams(Tuple.Create("dateMin", "0w"), Tuple.Create("dateMax", "2w"));

            atomic.webClient.SetSortDescending();

            //int currPage;

            bool checkExist = false;

            atomic.selector.Init(atomic.webClient, atomic);

            atomic.selector.InitDateInterval();

            var context = new ChessAtomicCrawlingContext();

            while (atomic.selector.NextDateInterval() && failedMonthInSequence < 50)
            {
                // 1
                watch.t[1].Start();

                //currPage = 1;
                //webClient.SetPage(currPage);


                // 1
                watch.t[1].Stop();


                while (atomic.selector.NextPage())
                {


                //    bool keepParse = true;

                    try
                    {
                        // 2
                        watch.t[2].Start();
                        // получаем список игр в результатах поиска ( теперь будем извлекать id )
                        listOfGames = atomic.webClient.GetResponse();

                        // 2
                        watch.t[2].Stop();

                        // 3
                        watch.t[3].Start();

                        // извлекаем id в gamesId
                        atomic.ParsPageAndGetGamesId(listOfGames, ref gamesId);

                        // 3
                        watch.t[3].Stop();


                        // если в ответе не было списка игр, то завершаем парсинг
                        if (gamesId.Count == 0) break;

                        while (gamesId.Count > 0)
                        {
                            using (webClient2)
                            {
                                string currGameId = gamesId.Dequeue();

                                string gameInfo = string.Empty;

                                // 4
                                watch.t[4].Start();

                                checkExist = context.AtomicGameInfo.Count(a => a.id == currGameId) > 0;

                                // 4
                                watch.t[4].Stop();

                                if (checkExist)
                                {
                                    continue;
                                }

                                // загружаем инфу о текущей игре
                                try
                                {
                                    // 5
                                    watch.t[5].Start();

                                    gameInfo = webClient2.DownloadString("https://en.lichess.org/" + currGameId);

                                    // 5
                                    watch.t[5].Stop();

                                    // 6
                                    watch.t[6].Start();

                                    // парсим ответ, полученный в предыдущем запросе
                                    //keepParse = 
                                    atomic.ParseGame(currGameId, gameInfo);

                                    // 6
                                    watch.t[6].Stop();

                                    //failsInSequence = 0;
                                }
                                catch (Exception exc)
                                {
                                    watch.t[5].Stop();
                                    watch.t[6].Stop();

                                    // 7
                                    watch.t[7].Start();

                                    //failedDownloads.Enqueue(currGameId);
                                    Thread.Sleep(2000);
                                    //++failsInSequence;

                                    gamesId.Enqueue(currGameId);

                                    // 7
                                    watch.t[7].Stop();


                                }
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException exc)
                    {
                        watch.t[2].Stop();
                        watch.t[3].Stop();
                        watch.t[4].Stop();

                        //keepParse = false;
                    }
                    catch (Exception exc)
                    {
                        watch.t[2].Stop();
                        watch.t[3].Stop();
                        watch.t[4].Stop();

                        //failedPages.Enqueue(currPage.ToString());

                        // 8
                        watch.t[8].Start();

                        //--currPage;

                        Thread.Sleep(2000);
                        ++failedPagesInSequence;

                       // if (failedPagesInSequence > 5) keepParse = false;

                        // 8
                        watch.t[8].Stop();

                    }


                    // увеличиваем страницу
                    //++currPage;
                    // теперь будем получать список игр со следующей страницы
                    //webClient.SetPage(currPage);

                    atomic.selector.NextPage();

                    // temporarily restriction one page for checkout
                //    if (!keepParse) break;
                }



                atomic.selector.NextDateInterval();



                if (atomic.gameElements.Count > 0)
                {
                    // 9
                    watch.t[9].Start();

                    context.AtomicGameInfo.AddRange(atomic.gameElements);

                    // 9
                    watch.t[9].Stop();

                    try
                    {
                        // 10
                        watch.t[10].Start();

                        context.SaveChanges();

                        // 10
                        watch.t[10].Stop();
                    }
                    catch (Exception exc)
                    {
                        // 10
                        watch.t[10].Stop();

                    }
                    finally
                    {
                        atomic.gameElements.Clear();
                    }
                }
                else
                {
                    ++failedMonthInSequence;
                }


            }

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
                    if (g.moves.Length >= startIndex + 4)
                    {
                        nextMove = g.moves.Substring(startIndex, 4);

                        if (hints.hints.ContainsKey(nextMove)) ++hints.hints[nextMove];
                        else hints.hints.Add(nextMove, 1);
                    }
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

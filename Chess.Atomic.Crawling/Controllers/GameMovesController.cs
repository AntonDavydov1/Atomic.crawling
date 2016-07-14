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
                string[] players = new string[] { /*"tipau", "krasss", "penguingim1", "Fyuxs", "Mabrook",*/
                "pashpash", "hUdSonZiNho", "Ardavan74", "anthonypower1", "Ghostknight",
                "FlyAway", "Rhex", "moustruito", "vampire_rodent", "MagoAtomico",
                "Gannet", "lord-zero", "victorvi", "kreedz", "jananth1",
                "OrigamiCaptainFaN", "Chacarron", "nnnnnnn7", "FixedPoint", "JimmeeX", "Frmiranda137", "slowwinning", "Sikstufff", "Shampanskoe_Vino", "Pasili"



//31	 NM blitzbullet	2367	14
//32	 Run_it	2364	56
//33	 doggonit	2361	165
//34	 MathNetaji	2354	6
//35	 Nonpareil	2342	29
//36	 Caustic	2342	45
//37	 j0e	2337	15
//38	 mob123	2326	39
//39	 NM Deathmaster	2322	33
//40	 LANGSDORF	2303	21
//41	 ukimix	2303	30
//42	 Sanhedrin	2300	1
//43	 Unihedron	2298	18
//44	 Godislove	2282	82
//45	 Kleerkast	2282	41
//46	 brd123	2281	78
//47	 TheLlamaLord	2281	23
//48	 AC8	2279	19
//49	 yoavjm	2279	17
//50	 ivigorsev61	2269	6
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
//91	 scottecs	2148	4
//92	 kamikazee	2147	72
//93	 Hyp3rspeed	2144	43
//94	 DaeneryStormborn	2141	16
//95	 Italianmachine97	2139	6
//96	 wowa1963	2134	3
//97	 Sorsi	2134	6
//98	 seanysean	2133	1
//99	 sansanich97	2127	109
//100	 ChessWhiz	2126	53
                
                };

                for (int i = 0; i < players.Length; ++i)
                    ParseOnePlayer(players[i]);


                //return View("~/Views/Home/Index.cshtml", atomic.gameElements.Take(10));
            }

            return View("~/Views/Home/Index.cshtml", "ModelState not valid");
        }

        private static void ParseOnePlayer(string playerId)
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

            int failedMonthInSequence = 0;

            using (webClient)
            {
                // получаем список игр в результатах поиска (сейчас только чтобы получить количество игр)
                listOfGames = webClient.DownloadString(url);
                countGames = atomic.ParseFirstPage(ref listOfGames);



                int currWeek = 0;

                webClient.QueryString.Add("dateMin", "0w");
                webClient.QueryString.Add("dateMax", "2w");

                int currPage;

                while (atomic.GetCountGames() < countGames && failedMonthInSequence < 50)
                {
                    currPage = 1;
                    webClient.QueryString["page"] = "1";

                    using (var context = new ChessAtomicCrawlingContext())
                    {

                        while (true)
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

                                        if (context.AtomicGameInfo.Count(a => a.id == currGameId) > 0)
                                        {
                                            continue;
                                        }

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
                            catch (ArgumentOutOfRangeException exc)
                            {
                                keepParse = false;
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

                        currWeek += 2;

                        webClient.QueryString["dateMin"] = currWeek.ToString() + "w";
                        webClient.QueryString["dateMax"] = (currWeek + 2).ToString() + "w";



                        if (atomic.gameElements.Count > 0)
                        {

                            context.AtomicGameInfo.AddRange(atomic.gameElements);

                            try
                            {
                                context.SaveChanges();
                            }
                            catch (Exception exc)
                            { }
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

using Chess.Atomic.Crawling.Controllers;
using Chess.Atomic.Crawling.Models;
using Chess.Atomic.Crawling.SignalR_hubs;
using Chess.Atomic.Crawling.WebClasses;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;

namespace Chess.Atomic.Crawling.ParsingClasses
{
    public class Crawling
    {
        //    // Singleton instance
        //    private readonly static Lazy<Crawling> _instance = new Lazy<Crawling>(() => new Crawling(GlobalHost.ConnectionManager.GetHubContext<ProgressHub>().Clients));

        //    private Crawling(IHubConnectionContext<dynamic> clients)
        //    {
        //        Clients = clients;
        //    }

        //    public static Crawling Instance
        //    {
        //        get
        //        {
        //            return _instance.Value;
        //        }
        //    }

        //    private IHubConnectionContext<dynamic> Clients
        //    {
        //        get;
        //        set;
        //    }


        //    private PlayersController plController = new PlayersController();

        public static void ParseOnePlayer(string playerId)
        {
            if (String.IsNullOrEmpty(playerId)) return;

            

            //Clients.All.Update("parsing ...", playerId);


            var wc = new AtomicWebClient();

            wc.SetUrl(string.Format(@"https://lichess.org/api/user/{0}/games", playerId));

            wc.SetParams(Tuple.Create("with_moves", "1"), Tuple.Create("nb", "100"), Tuple.Create("page", "1"));

            MainResult res = null;


            using (var context = new ChessAtomicCrawlingContext())
            {
                do
                {
                    string response = wc.GetResponse();
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    res = jss.Deserialize<MainResult>(response);

                    if (res == null) continue;

                    foreach (GameResult game in res.currentPageResults)
                    {
                        GameInfo gi = new GameInfo();

                        gi.id = game.id;
                        gi.rated = game.rated;
                        gi.variant = game.variant;
                        gi.speed = game.speed;
                        gi.perf = game.perf;
                        gi.createdAt = game.createdAt;
                        gi.turns = game.turns;
                        gi.status = game.status;
                        
                        if (game.rated)
                        {
                            gi.clockInitial = game.clock.initial;
                            gi.clockIncrement = game.clock.increment;
                            gi.clockTotalTime = game.clock.totalTime;
                        }
                        
                        gi.raitingWhite = game.players.white.rating;
                        gi.idWhite = game.players.white.userId;
                        gi.raitingBlack = game.players.black.rating;
                        gi.idBlack = game.players.black.userId;
                        gi.moves = game.moves;
                        gi.winner = game.winner;
                        gi.url = game.url;
                        gi.timeCreated = DateTime.Now;

                        if (context.GameInfoes.SingleOrDefault(g => g.id == gi.id) == null)
                        {
                            context.GameInfoes.Add(gi);
                        }


                    }

                    context.SaveChanges();

                    wc.SetParams(Tuple.Create("page", res.nextPage.ToString()));

                }
                while (res == null || res.nextPage != null);
            }
            //{
            //    string bruto;

            //    bool succeed;

            //    while (atomic.selector.NextPage())
            //    {
            //        bruto = string.Empty;

            //        succeed = false;

            //        do
            //        {
            //            try
            //            {
            //                // получаем список игр в результатах поиска ( теперь будем извлекать id
            //                bruto = atomic.webClient.GetResponse();
            //                succeed = true;
            //            }
            //            catch (Exception exc)
            //            {
            //                Thread.Sleep(1000);
            //            }
            //        }
            //        while (!succeed);


            //        // извлекаем id в gamesId
            //        atomic.ParsePageAndGetGamesId(bruto, ref gamesId);

            //        // если в ответе не было списка игр, то завершаем парсинг
            //        // эта строка делает ту работу, которую должна делать atomic.selector.NextPage()
            //        if (gamesId.Count == 0) break;

            //        while (gamesId.Count > 0)
            //        {
            //            using (webClient2)
            //            {
            //                string currGameId = gamesId.Dequeue();

            //                string gameInfo = string.Empty;

            //                //if (string.Equals(currGameId, "nmyPGv6q") || string.Equals(currGameId, "aMGHG40h"))
            //                //{
            //                //    int fg = 4;
            //                //}

            //                var games = (from g in context.AtomicGameInfo
            //                             select g)
            //                             .ToList();

            //                //var elem = games.FirstOrDefault(a => string.Equals(a.id, currGameId));

            //                alreadyExist = games.FirstOrDefault(a => string.Equals(a.id, currGameId)) != null;

            //                //alreadyExist = context.AtomicGameInfo.First(a => string.Equals(a.id, "aMGHG40h")) != null;

            //                if (alreadyExist) continue;

            //                // загружаем инфу о текущей игре
            //                try
            //                {
            //                    gameInfo = webClient2.DownloadString("https://en.lichess.org/" + currGameId);

            //                    // парсим ответ, полученный в предыдущем запросе
            //                    atomic.ParseGame(currGameId, gameInfo, plController);

            //                    Clients.All.Update(++count + "% completed", playerId);

            //                }
            //                catch (Exception exc)
            //                {
            //                    Thread.Sleep(1000);
            //                    gamesId.Enqueue(currGameId);

            //                }
            //            }
            //        }

            //    }

            //    if (atomic.gameElements.Count > 0)
            //    {
            //        context.AtomicGameInfo.AddRange(atomic.gameElements);

            //        try
            //        {
            //            context.SaveChanges();
            //        }
            //        catch (Exception exc)
            //        {
            //        }
            //        finally
            //        {
            //            atomic.gameElements.Clear();
            //        }
            //    }
            //}

            //Clients.All.Update(count + " games parsed ", playerId);

        }

        //    public static void ParsePlayerGameShorts(string playerId)
        //    {

        //        int count = 0;

        //        AtomicParser atomic = new AtomicParser();
        //        Queue<string> gamesId = new Queue<string>();

        //        atomic.webClient.Init(playerId);


        //        bool alreadyExist = false;

        //        atomic.selector.Init(atomic.webClient, atomic);

        //        atomic.selector.InitDateInterval();
        //        atomic.selector.InitPage();

        //        var context = new ChessAtomicCrawlingContext();

        //        while (atomic.selector.NextDateInterval())
        //        {
        //            string bruto;

        //            bool succeed;

        //            while (atomic.selector.NextPage())
        //            {
        //                bruto = string.Empty;

        //                succeed = false;

        //                do
        //                {
        //                    try
        //                    {
        //                        // получаем список игр в результатах поиска ( теперь будем извлекать id
        //                        bruto = atomic.webClient.GetResponse();
        //                        succeed = true;
        //                    }
        //                    catch (Exception exc)
        //                    {
        //                        Thread.Sleep(1000);
        //                    }
        //                }
        //                while (!succeed);


        //                // извлекаем id в gamesId
        //                atomic.ParsePageAndGetGamesId(bruto, ref gamesId);

        //                //// если в ответе не было списка игр, то завершаем парсинг
        //                //// эта строка делает ту работу, которую должна делать atomic.selector.NextPage()
        //                //if (gamesId.Count == 0) break;

        //                while (gamesId.Count > 0)
        //                {
        //                    string currGameId = gamesId.Dequeue();

        //                    alreadyExist = context.GameShorts.FirstOrDefault(g => String.Equals(g.id, currGameId)) != null;

        //                    if (!alreadyExist) context.GameShorts.Add(new GameShort { id = currGameId });
        //                }

        //                context.SaveChanges();

        //            }


        //        }

        //        //Clients.All.Update(count + " games parsed ", playerId);

        //    }
    }
}
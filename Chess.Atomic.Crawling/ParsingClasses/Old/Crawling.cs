using Chess.Atomic.Crawling.Controllers;
using Chess.Atomic.Crawling.Models;
using Chess.Atomic.Crawling.SignalR_hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

namespace Chess.Atomic.Crawling.ParsingClasses
{
    //public class Crawling
    //{
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

    //    public void ParseOnePlayer(string playerId)
    //    {
    //        //Clients.All.Update("parsing ...", playerId);

    //        int count = 0;

    //        AtomicParser atomic = new AtomicParser();
    //        Queue<string> gamesId = new Queue<string>();
    //        var webClient2 = new WebClient();

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

    //                // если в ответе не было списка игр, то завершаем парсинг
    //                // эта строка делает ту работу, которую должна делать atomic.selector.NextPage()
    //                if (gamesId.Count == 0) break;

    //                while (gamesId.Count > 0)
    //                {
    //                    using (webClient2)
    //                    {
    //                        string currGameId = gamesId.Dequeue();

    //                        string gameInfo = string.Empty;

    //                        //if (string.Equals(currGameId, "nmyPGv6q") || string.Equals(currGameId, "aMGHG40h"))
    //                        //{
    //                        //    int fg = 4;
    //                        //}

    //                        var games = (from g in context.AtomicGameInfo
    //                                     select g)
    //                                     .ToList();

    //                        //var elem = games.FirstOrDefault(a => string.Equals(a.id, currGameId));

    //                        alreadyExist = games.FirstOrDefault(a => string.Equals(a.id, currGameId)) != null;

    //                        //alreadyExist = context.AtomicGameInfo.First(a => string.Equals(a.id, "aMGHG40h")) != null;

    //                        if (alreadyExist) continue;

    //                        // загружаем инфу о текущей игре
    //                        try
    //                        {
    //                            gameInfo = webClient2.DownloadString("https://en.lichess.org/" + currGameId);

    //                            // парсим ответ, полученный в предыдущем запросе
    //                            atomic.ParseGame(currGameId, gameInfo, plController);

    //                            Clients.All.Update(++count + "% completed", playerId);

    //                        }
    //                        catch (Exception exc)
    //                        {
    //                            Thread.Sleep(1000);
    //                            gamesId.Enqueue(currGameId);

    //                        }
    //                    }
    //                }

    //            }

    //            if (atomic.gameElements.Count > 0)
    //            {
    //                context.AtomicGameInfo.AddRange(atomic.gameElements);

    //                try
    //                {
    //                    context.SaveChanges();
    //                }
    //                catch (Exception exc)
    //                {
    //                }
    //                finally
    //                {
    //                    atomic.gameElements.Clear();
    //                }
    //            }
    //        }

    //        Clients.All.Update(count + " games parsed ", playerId);

    //    }

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
    //}
}
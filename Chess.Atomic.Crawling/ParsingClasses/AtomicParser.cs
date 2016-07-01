using Chess.Atomic.Crawling.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.ParsingClasses
{
    public class AtomicParser
    {
        int countGames = 0;
        const string countGamesLabel = "<div class=\"search_status\">\n    <strong>";   // <div class="search_status"> <strong>1,585 games found</strong>
        const string gameElementLabel = "<div class=\"game_row paginated_element\">";

        public List<AtomicGameInfo> gameElements = new List<AtomicGameInfo>();


        public int GetCountGames()
        {
            return countGames;
        }

        public int ParseFirstPage(ref string searchResult)
        {
            searchResult = searchResult.Substring(searchResult.IndexOf(countGamesLabel) + countGamesLabel.Length); // remove all previous text, he is not needed
            string count = searchResult.Substring(0, 19); // 19 - expected max count 999,999
            count = count.Remove(count.IndexOf(" games found"));

            int countGamesTotal = 0;

            try
            {
                countGamesTotal = Int32.Parse(count, System.Globalization.NumberStyles.AllowThousands, new CultureInfo("en-US"));
            }
            catch (Exception)
            { }           

            return countGamesTotal;
        }

        public void ParseListOfGames(string searchResult, ref Queue<string> gamesId)
        {
            searchResult = searchResult.Substring(searchResult.IndexOf(gameElementLabel));

            string[] gamesIdArray = searchResult.Split(new string[] { gameElementLabel }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < gamesIdArray.Length; ++i)
            {
                gamesId.Enqueue(ExtractGameId(gamesIdArray[i]));
            }
        }

        const string gameIdLabel = "\n  \n  \n  <a href=\"/";

        string ExtractGameId(string gameOverview)
        {
            string res = string.Empty;
            try
            {
                res = gameOverview.Substring(gameOverview.IndexOf(gameIdLabel) + gameIdLabel.Length, 8);
            }
            catch (Exception) { }

            return res;
        }

        const string whitePlayerLabel = "<div class=\"player color-icon is white\">\n        <a  class=\"user_link ulpt\" href=\"/@/";
        const string blackPlayerLabel = "<div class=\"player color-icon is black\">\n        <a  class=\"user_link ulpt\" href=\"/@/";
        const string MoveLabel = ",\"uci\":\"";

        const string StatusLabel = "<div class=\"status\">";
        
        //const string sep1 = "<div id=\"chat\" class=\"side_box\"></div>";
        //const string sep2 = "";

        public void ParseGame(string gameId, string gameInfo)
        {
            AtomicGameInfo element = new AtomicGameInfo { id = gameId };

            gameInfo = gameInfo.Substring(gameInfo.IndexOf(whitePlayerLabel) + whitePlayerLabel.Length);
            element.white = gameInfo.Substring(0, gameInfo.IndexOf("\">"));

            gameInfo = gameInfo.Substring(gameInfo.IndexOf(blackPlayerLabel) + blackPlayerLabel.Length);
            element.black = gameInfo.Substring(0, gameInfo.IndexOf("\">"));

            gameInfo = gameInfo.Substring(gameInfo.IndexOf(StatusLabel) + StatusLabel.Length);
            string status = gameInfo.Remove(gameInfo.IndexOf("</div>"));

            if (status.Contains("Black is victorious")) element.status = GameStatus.BlackVictorious;
            else if (status.Contains("White is victorious")) element.status = GameStatus.WhiteVictorious;
            else if (status.Contains("Draw")) element.status = GameStatus.Draw;
            else element.status = GameStatus.Unknown;
                        
            int currMoveIndex = gameInfo.IndexOf(MoveLabel);

            while (currMoveIndex != -1)
            {
                gameInfo = gameInfo.Substring(currMoveIndex + MoveLabel.Length);
                element.moves += gameInfo.Substring(0, 4);

                currMoveIndex = gameInfo.IndexOf(MoveLabel);
            }

            gameElements.Add(element);

            ++countGames;
        }
    }
}
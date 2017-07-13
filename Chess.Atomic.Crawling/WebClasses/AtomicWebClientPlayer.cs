using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.WebClasses
{
    public class AtomicWebClientPlayer : AtomicWebClient
    {
        public bool init = false;

        public void Init(string playerId) // this set of params will get the info about player raiting and count of games
        {            
            ClearParams();

            url = String.Format("https://en.lichess.org/@/{0}/search", playerId);
                        
            SetParams(Tuple.Create("perf", "14"), Tuple.Create("page", "1"), Tuple.Create("mode", "1"), Tuple.Create("ratingMin", "2300"));  // 14 is identifier for atomic games (as I realized), mode = 1 - rated games only

            init = true;
        }

        public void InitForGetRaiting(string playerId)
        {
            ClearParams();

            url = string.Format("https://en.lichess.org/@/{0}/perf/atomic", playerId);
            
            init = true;
        }

        public void SetPage(int page)
        {
            SetParams(Tuple.Create("page", page.ToString()));
        }

        public void SetSortDescending()
        {
            SetParams(Tuple.Create("sort.field", "a"), Tuple.Create("sort.order", "desc"));
        }

        public void SetForFirstGame()
        {
            SetParams(Tuple.Create("sort.field", "a"), Tuple.Create("sort.order", "desc"), Tuple.Create("dateMin", string.Empty), Tuple.Create("dateMax", string.Empty));

        }

    }
}
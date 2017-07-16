using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class ChessAtomicCrawlingContext : DbContext
    {
    
        public ChessAtomicCrawlingContext() : base("name=ChessAtomicCrawlingNew")
        {
        }

        //public DbSet<AtomicGameInfo> AtomicGameInfo { get; set; }

        public DbSet<Player> Players { get; set; }

        //public DbSet<UpdatesInfo> Updates { get; set; }

        public DbSet<AtomicGameInfoOld> AtomicGameInfoOld { get; set; }

        //public DbSet<GameShort> GameShorts { get; set; }


    
    }
}

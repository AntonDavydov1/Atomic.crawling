﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class ChessAtomicCrawlingContextOld : DbContext
    {
    
        public ChessAtomicCrawlingContextOld() : base("name=ChessAtomicCrawlingOld")
        {
        }

        //public DbSet<AtomicGameInfo> AtomicGameInfo { get; set; }

        //public DbSet<GameInfo> GameInfoes { get; set; }

        //public DbSet<UpdatesInfo> Updates { get; set; }

        public DbSet<AtomicGameInfoOld> AtomicGameInfoOlds { get; set; }

        //public DbSet<AtomicGameInfoOld> AtomicGameInfoBackUp { get; set; }
        //public DbSet<GameShort> GameShorts { get; set; }



    }
}

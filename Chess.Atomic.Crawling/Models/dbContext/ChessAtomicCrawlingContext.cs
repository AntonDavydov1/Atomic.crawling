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

        public DbSet<GameInfo> GameInfoes { get; set; }

        //public DbSet<UpdatesInfo> Updates { get; set; }

        public DbSet<AtomicGameInfoOld> AtomicGameInfoOlds { get; set; }

        //public DbSet<GameShort> GameShorts { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameInfo>().Property(p => p.timeCreated).HasColumnType("datetime2");
        }
    }
}

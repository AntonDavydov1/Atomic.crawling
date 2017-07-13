using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class ChessAtomicCrawlingContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ChessAtomicCrawlingContext() : base("name=ChessAtomicCrawlingContext")
        {
        }

        public System.Data.Entity.DbSet<Chess.Atomic.Crawling.Models.AtomicGameInfo> AtomicGameInfo { get; set; }

        public System.Data.Entity.DbSet<Chess.Atomic.Crawling.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<Chess.Atomic.Crawling.Models.UpdatesInfo> Updates { get; set; }

        public System.Data.Entity.DbSet<Chess.Atomic.Crawling.Models.AtomicGameInfoOld> AtomicGameInfoOld { get; set; }
    
    }
}

namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameInfoes",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        rated = c.Boolean(nullable: false),
                        variant = c.String(),
                        speed = c.String(),
                        perf = c.String(),
                        createdAt = c.Int(nullable: false),
                        turns = c.Int(nullable: false),
                        status = c.String(),
                        clockInitial = c.Int(nullable: false),
                        clockIncrement = c.Int(nullable: false),
                        clockTotalTime = c.Int(nullable: false),
                        raitingWhite = c.Int(nullable: false),
                        raitingBlack = c.Int(nullable: false),
                        moves = c.String(),
                        winner = c.String(),
                        url = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.AtomicGameInfoes");
            DropTable("dbo.GameShorts");
            DropTable("dbo.Players");
            DropTable("dbo.UpdatesInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UpdatesInfoes",
                c => new
                    {
                        playerName = c.String(nullable: false, maxLength: 128),
                        lastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.playerName);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                        raiting = c.Int(nullable: false),
                        localCount = c.Int(nullable: false),
                        lichessCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.name);
            
            CreateTable(
                "dbo.GameShorts",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        white = c.String(),
                        black = c.String(),
                        whiteRaiting = c.Int(nullable: false),
                        blackRaiting = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AtomicGameInfoes",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        white = c.String(),
                        black = c.String(),
                        moves = c.String(),
                        status = c.Int(nullable: false),
                        whiteRaiting = c.Int(nullable: false),
                        blackRaiting = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.GameInfoes");
        }
    }
}

namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.AtomicGameInfoOlds",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        white = c.String(),
                        black = c.String(),
                        moves = c.String(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                        raiting = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.name);
            
            CreateTable(
                "dbo.UpdatesInfoes",
                c => new
                    {
                        playerName = c.String(nullable: false, maxLength: 128),
                        lastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.playerName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UpdatesInfoes");
            DropTable("dbo.Players");
            DropTable("dbo.AtomicGameInfoOlds");
            DropTable("dbo.AtomicGameInfoes");
        }
    }
}

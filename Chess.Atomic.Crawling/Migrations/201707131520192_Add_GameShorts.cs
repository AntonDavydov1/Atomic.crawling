namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_GameShorts : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameShorts");
        }
    }
}

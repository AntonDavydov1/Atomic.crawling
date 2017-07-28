namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablerating : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameInfoes", "raitingWhite", c => c.Int());
            AlterColumn("dbo.GameInfoes", "raitingBlack", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameInfoes", "raitingBlack", c => c.Int(nullable: false));
            AlterColumn("dbo.GameInfoes", "raitingWhite", c => c.Int(nullable: false));
        }
    }
}

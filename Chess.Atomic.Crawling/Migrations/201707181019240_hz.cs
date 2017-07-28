namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameInfoes", "idWhite", c => c.String());
            AddColumn("dbo.GameInfoes", "idBlack", c => c.String());
            AlterColumn("dbo.GameInfoes", "createdAt", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameInfoes", "createdAt", c => c.Int(nullable: false));
            DropColumn("dbo.GameInfoes", "idBlack");
            DropColumn("dbo.GameInfoes", "idWhite");
        }
    }
}

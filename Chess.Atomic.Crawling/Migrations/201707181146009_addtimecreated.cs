namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtimecreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameInfoes", "timeCreated", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameInfoes", "timeCreated");
        }
    }
}

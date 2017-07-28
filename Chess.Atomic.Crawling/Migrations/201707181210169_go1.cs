namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GameInfoes", "timeCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameInfoes", "timeCreated", c => c.Long(nullable: false));
        }
    }
}

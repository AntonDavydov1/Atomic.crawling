namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameInfoes", "timeCreated", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameInfoes", "timeCreated", c => c.Binary());
        }
    }
}

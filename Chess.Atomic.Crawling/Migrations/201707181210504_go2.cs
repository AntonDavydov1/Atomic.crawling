namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameInfoes", "timeCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameInfoes", "timeCreated");
        }
    }
}

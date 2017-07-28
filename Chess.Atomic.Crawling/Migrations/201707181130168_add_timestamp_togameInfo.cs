namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_timestamp_togameInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameInfoes", "timeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameInfoes", "timeStamp");
        }
    }
}

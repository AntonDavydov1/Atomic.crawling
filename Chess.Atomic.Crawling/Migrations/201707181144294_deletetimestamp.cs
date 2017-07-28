namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetimestamp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GameInfoes", "timeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameInfoes", "timeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}

namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountsToPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "localCount", c => c.Int(nullable: false));
            AddColumn("dbo.Players", "lichessCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "lichessCount");
            DropColumn("dbo.Players", "localCount");
        }
    }
}

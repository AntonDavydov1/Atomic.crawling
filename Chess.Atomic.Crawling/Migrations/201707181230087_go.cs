namespace Chess.Atomic.Crawling.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class go : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameInfoes", "index", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameInfoes", "index");
        }
    }
}

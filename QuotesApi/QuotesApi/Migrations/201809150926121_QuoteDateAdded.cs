namespace QuotesApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuoteDateAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotes", "CreatedAt");
        }
    }
}

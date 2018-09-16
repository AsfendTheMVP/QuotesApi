namespace QuotesWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuotesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 25),
                        Author = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 500),
                        Type = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Quotes");
        }
    }
}

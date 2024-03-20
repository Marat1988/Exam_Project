namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableRecycler : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recyclers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        DisplayPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShippingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recyclers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Recyclers", new[] { "UserId" });
            DropTable("dbo.Recyclers");
        }
    }
}

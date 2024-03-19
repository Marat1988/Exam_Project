namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableLineOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "UserId" });
            CreateTable(
                "dbo.LineOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                        DisplayPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShippingPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AlterColumn("dbo.Orders", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LineOrders", "OrderId", "dbo.Orders");
            DropIndex("dbo.LineOrders", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.Orders", "UserId", c => c.String(maxLength: 128));
            DropTable("dbo.LineOrders");
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}

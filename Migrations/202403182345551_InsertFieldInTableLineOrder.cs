namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertFieldInTableLineOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LineOrders", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.LineOrders", "ProductId");
            AddForeignKey("dbo.LineOrders", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineOrders", "ProductId", "dbo.Products");
            DropIndex("dbo.LineOrders", new[] { "ProductId" });
            DropColumn("dbo.LineOrders", "ProductId");
        }
    }
}

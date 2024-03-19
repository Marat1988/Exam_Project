namespace Store.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableSupplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            AddColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "SupplierId");
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Suppliers", new[] { "Name" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropColumn("dbo.Products", "SupplierId");
            DropTable("dbo.Suppliers");
        }
    }
}

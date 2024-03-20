namespace Store.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableGroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "UQ_GroupName");
            
            AddColumn("dbo.Products", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "GroupId");
            AddForeignKey("dbo.Products", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "GroupId", "dbo.Groups");
            DropIndex("dbo.Products", new[] { "GroupId" });
            DropIndex("dbo.Groups", "UQ_GroupName");
            DropColumn("dbo.Products", "GroupId");
            DropTable("dbo.Groups");
        }
    }
}

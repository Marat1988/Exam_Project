namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePersonalDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PersonalDiscount", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PersonalDiscount");
        }
    }
}

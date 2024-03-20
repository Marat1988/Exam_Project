namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdFilePhooto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Photo");
        }
    }
}

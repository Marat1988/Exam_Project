namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "DateBirthDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "DateBirthDay", c => c.DateTime(nullable: false));
        }
    }
}

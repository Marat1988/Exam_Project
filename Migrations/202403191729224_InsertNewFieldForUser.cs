namespace Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertNewFieldForUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 20));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 15));
            AddColumn("dbo.AspNetUsers", "Patronymic", c => c.String(maxLength: 25));
            AddColumn("dbo.AspNetUsers", "DateBirthDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateBirthDay");
            DropColumn("dbo.AspNetUsers", "Patronymic");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}

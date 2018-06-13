namespace MyColours.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameAndSurnameAddedToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}

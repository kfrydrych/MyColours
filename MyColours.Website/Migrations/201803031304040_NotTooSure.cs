namespace MyColours.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotTooSure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Discriminator");
        }
    }
}

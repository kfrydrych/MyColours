namespace MyColours.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndividualProductPriceCapturedInTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionLines", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionLines", "Price");
        }
    }
}

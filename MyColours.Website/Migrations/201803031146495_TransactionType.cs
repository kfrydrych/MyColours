namespace MyColours.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transactions", "TransactionType_Id", c => c.Int());
            CreateIndex("dbo.Transactions", "TransactionType_Id");
            AddForeignKey("dbo.Transactions", "TransactionType_Id", "dbo.TransactionTypes", "Id");

            Sql("INSERT INTO [dbo].[TransactionTypes] VALUES ('Intake')");
            Sql("INSERT INTO [dbo].[TransactionTypes] VALUES ('Disposal')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransactionType_Id", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "TransactionType_Id" });
            DropColumn("dbo.Transactions", "TransactionType_Id");
            DropTable("dbo.TransactionTypes");
        }
    }
}

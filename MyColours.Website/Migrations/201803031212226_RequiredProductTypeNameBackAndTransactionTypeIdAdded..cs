namespace MyColours.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredProductTypeNameBackAndTransactionTypeIdAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "TransactionType_Id", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "TransactionType_Id" });
            RenameColumn(table: "dbo.Transactions", name: "TransactionType_Id", newName: "TransactionTypeId");
            AlterColumn("dbo.ProductTypes", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Transactions", "TransactionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "TransactionTypeId");
            AddForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "TransactionTypeId" });
            AlterColumn("dbo.Transactions", "TransactionTypeId", c => c.Int());
            AlterColumn("dbo.ProductTypes", "Name", c => c.String(maxLength: 50));
            RenameColumn(table: "dbo.Transactions", name: "TransactionTypeId", newName: "TransactionType_Id");
            CreateIndex("dbo.Transactions", "TransactionType_Id");
            AddForeignKey("dbo.Transactions", "TransactionType_Id", "dbo.TransactionTypes", "Id");
        }
    }
}

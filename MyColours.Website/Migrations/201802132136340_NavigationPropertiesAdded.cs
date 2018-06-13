namespace MyColours.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NavigationPropertiesAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransactionLines", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.TransactionLines", "Transaction_Id", "dbo.Transactions");
            DropIndex("dbo.TransactionLines", new[] { "Product_Id" });
            DropIndex("dbo.TransactionLines", new[] { "Transaction_Id" });
            RenameColumn(table: "dbo.TransactionLines", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.TransactionLines", name: "Transaction_Id", newName: "TransactionId");
            AlterColumn("dbo.TransactionLines", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.TransactionLines", "TransactionId", c => c.Int(nullable: false));
            CreateIndex("dbo.TransactionLines", "ProductId");
            CreateIndex("dbo.TransactionLines", "TransactionId");
            AddForeignKey("dbo.TransactionLines", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TransactionLines", "TransactionId", "dbo.Transactions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionLines", "TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.TransactionLines", "ProductId", "dbo.Products");
            DropIndex("dbo.TransactionLines", new[] { "TransactionId" });
            DropIndex("dbo.TransactionLines", new[] { "ProductId" });
            AlterColumn("dbo.TransactionLines", "TransactionId", c => c.Int());
            AlterColumn("dbo.TransactionLines", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.TransactionLines", name: "TransactionId", newName: "Transaction_Id");
            RenameColumn(table: "dbo.TransactionLines", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.TransactionLines", "Transaction_Id");
            CreateIndex("dbo.TransactionLines", "Product_Id");
            AddForeignKey("dbo.TransactionLines", "Transaction_Id", "dbo.Transactions", "Id");
            AddForeignKey("dbo.TransactionLines", "Product_Id", "dbo.Products", "Id");
        }
    }
}

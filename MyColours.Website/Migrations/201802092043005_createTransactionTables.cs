namespace MyColours.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTransactionTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(),
                        Transaction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Transactions", t => t.Transaction_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Transaction_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        InvoiceNumber = c.String(),
                        InvoiceValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionLines", "Transaction_Id", "dbo.Transactions");
            DropForeignKey("dbo.TransactionLines", "Product_Id", "dbo.Products");
            DropIndex("dbo.TransactionLines", new[] { "Transaction_Id" });
            DropIndex("dbo.TransactionLines", new[] { "Product_Id" });
            DropTable("dbo.Transactions");
            DropTable("dbo.TransactionLines");
        }
    }
}

namespace MyColours.Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Manufacturers VALUES ('Matrix')");

            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 100),
                        Quantity = c.Int(nullable: false),
                        Manufacturer_Id = c.Int(nullable: false),
                        ProductType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductTypes", t => t.ProductType_Id, cascadeDelete: true)
                .Index(t => t.Manufacturer_Id)
                .Index(t => t.ProductType_Id);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO ProductTypes VALUES ('Colour')");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductType_Id", "dbo.ProductTypes");
            DropForeignKey("dbo.Products", "Manufacturer_Id", "dbo.Manufacturers");
            DropIndex("dbo.Products", new[] { "ProductType_Id" });
            DropIndex("dbo.Products", new[] { "Manufacturer_Id" });
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Products");
            DropTable("dbo.Manufacturers");
        }
    }
}

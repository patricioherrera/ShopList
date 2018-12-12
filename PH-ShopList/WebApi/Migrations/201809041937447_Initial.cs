namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Father",
                c => new
                    {
                        FatherId = c.Int(nullable: false, identity: true),
                        FatherName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FatherId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        CodeProduct = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        UM = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShopList_ShopListId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ShopList", t => t.ShopList_ShopListId)
                .Index(t => t.ShopList_ShopListId);
            
            CreateTable(
                "dbo.ShopList",
                c => new
                    {
                        ShopListId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Initial = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShopListId);
            
            CreateTable(
                "dbo.Son",
                c => new
                    {
                        SonId = c.Int(nullable: false, identity: true),
                        FatherId = c.Int(nullable: false),
                        SonName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ShopList_ShopListId", "dbo.ShopList");
            DropIndex("dbo.Product", new[] { "ShopList_ShopListId" });
            DropTable("dbo.Son");
            DropTable("dbo.ShopList");
            DropTable("dbo.Product");
            DropTable("dbo.Father");
        }
    }
}

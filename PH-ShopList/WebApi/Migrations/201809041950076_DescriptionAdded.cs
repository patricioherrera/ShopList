namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShopList", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShopList", "Description");
        }
    }
}

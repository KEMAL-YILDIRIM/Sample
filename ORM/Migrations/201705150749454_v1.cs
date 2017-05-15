namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order Details", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Order Details", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Territories", "RegionID", "dbo.Region");
            AddForeignKey("dbo.Order Details", "ProductID", "dbo.Products", "ProductID", cascadeDelete: true);
            AddForeignKey("dbo.Order Details", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
            AddForeignKey("dbo.Territories", "RegionID", "dbo.Region", "RegionID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Territories", "RegionID", "dbo.Region");
            DropForeignKey("dbo.Order Details", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Order Details", "ProductID", "dbo.Products");
            AddForeignKey("dbo.Territories", "RegionID", "dbo.Region", "RegionID");
            AddForeignKey("dbo.Order Details", "OrderID", "dbo.Orders", "OrderID");
            AddForeignKey("dbo.Order Details", "ProductID", "dbo.Products", "ProductID");
        }
    }
}

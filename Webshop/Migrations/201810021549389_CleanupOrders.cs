namespace Webshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanupOrders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "name");
            DropColumn("dbo.Orders", "address");
            DropColumn("dbo.Orders", "phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "phone", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.Orders", "address", c => c.String(maxLength: 255, unicode: false));
            AddColumn("dbo.Orders", "name", c => c.String(maxLength: 255, unicode: false));
            DropColumn("dbo.Orders", "Date");
        }
    }
}

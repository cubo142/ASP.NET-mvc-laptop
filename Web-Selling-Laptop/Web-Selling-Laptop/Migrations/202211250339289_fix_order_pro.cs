namespace Web_Selling_Laptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_order_pro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderProes", "SDTPro", c => c.String());
            AddColumn("dbo.OrderProes", "CusPro", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderProes", "CusPro");
            DropColumn("dbo.OrderProes", "SDTPro");
        }
    }
}

namespace Web_Selling_Laptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_userid_order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderProes", "UserID", "dbo.Users");
            DropIndex("dbo.OrderProes", new[] { "UserID" });
            AlterColumn("dbo.OrderProes", "UserID", c => c.Int());
            CreateIndex("dbo.OrderProes", "UserID");
            AddForeignKey("dbo.OrderProes", "UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProes", "UserID", "dbo.Users");
            DropIndex("dbo.OrderProes", new[] { "UserID" });
            AlterColumn("dbo.OrderProes", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderProes", "UserID");
            AddForeignKey("dbo.OrderProes", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}

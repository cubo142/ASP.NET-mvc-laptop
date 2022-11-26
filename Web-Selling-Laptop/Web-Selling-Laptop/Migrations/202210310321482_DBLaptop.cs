namespace Web_Selling_Laptop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBLaptop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CateId = c.Int(nullable: false, identity: true),
                        CateName = c.String(),
                    })
                .PrimaryKey(t => t.CateId);
            
            CreateTable(
                "dbo.Laptops",
                c => new
                    {
                        LaptopId = c.Int(nullable: false, identity: true),
                        LaptopName = c.String(nullable: false),
                        CPU = c.String(),
                        RAM = c.String(),
                        Card = c.String(),
                        HDH = c.String(),
                        USB = c.String(),
                        CateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LaptopId)
                .ForeignKey("dbo.Categories", t => t.CateId, cascadeDelete: true)
                .Index(t => t.CateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Laptops", "CateId", "dbo.Categories");
            DropIndex("dbo.Laptops", new[] { "CateId" });
            DropTable("dbo.Laptops");
            DropTable("dbo.Categories");
        }
    }
}

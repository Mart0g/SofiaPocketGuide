namespace SPG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Required_Fields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Place", "Category_Id", "dbo.PlaceCategory");
            DropIndex("dbo.Place", new[] { "Category_Id" });
            AlterColumn("dbo.Place", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Place", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Place", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Place", "Category_Id");
            AddForeignKey("dbo.Place", "Category_Id", "dbo.PlaceCategory", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Place", "Category_Id", "dbo.PlaceCategory");
            DropIndex("dbo.Place", new[] { "Category_Id" });
            AlterColumn("dbo.Place", "Category_Id", c => c.Int());
            AlterColumn("dbo.Place", "Address", c => c.String());
            AlterColumn("dbo.Place", "Name", c => c.String());
            CreateIndex("dbo.Place", "Category_Id");
            AddForeignKey("dbo.Place", "Category_Id", "dbo.PlaceCategory", "Id");
        }
    }
}

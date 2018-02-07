namespace SPG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactor_Database : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LexicalCategory", newName: "Need");
            DropForeignKey("dbo.Place", "Category_Id", "dbo.PlaceCategory");
            DropForeignKey("dbo.SubCategory", "NeedCategory_Id", "dbo.NeedCategory");
            DropForeignKey("dbo.SubCategory", "PlaceCategory_Id", "dbo.PlaceCategory");
            DropForeignKey("dbo.Place", "SubCategory_Id", "dbo.SubCategory");
            DropForeignKey("dbo.Word", "NeedCategory_Id", "dbo.NeedCategory");
            DropForeignKey("dbo.Word", "PlaceCategory_Id", "dbo.PlaceCategory");
            DropForeignKey("dbo.Word", "LexicalCategory_Id", "dbo.LexicalCategory");
            DropIndex("dbo.Place", new[] { "Category_Id" });
            DropIndex("dbo.Place", new[] { "SubCategory_Id" });
            DropIndex("dbo.SubCategory", new[] { "NeedCategory_Id" });
            DropIndex("dbo.SubCategory", new[] { "PlaceCategory_Id" });
            DropIndex("dbo.Word", new[] { "LexicalCategory_Id" });
            DropIndex("dbo.Word", new[] { "NeedCategory_Id" });
            DropIndex("dbo.Word", new[] { "PlaceCategory_Id" });
            RenameColumn(table: "dbo.Word", name: "LexicalCategory_Id", newName: "NeedId");
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VenueEntityTagEntities",
                c => new
                    {
                        VenueEntity_Id = c.Int(nullable: false),
                        TagEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VenueEntity_Id, t.TagEntity_Id })
                .ForeignKey("dbo.Venue", t => t.VenueEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagEntity_Id, cascadeDelete: true)
                .Index(t => t.VenueEntity_Id)
                .Index(t => t.TagEntity_Id);
            
            AddColumn("dbo.Message", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Word", "TagId", c => c.Int(nullable: false));
            AlterColumn("dbo.Message", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.Word", "NeedId", c => c.Int(nullable: false));
            CreateIndex("dbo.Message", "UserId");
            CreateIndex("dbo.Word", "NeedId");
            CreateIndex("dbo.Word", "TagId");
            AddForeignKey("dbo.Message", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Word", "TagId", "dbo.Tag", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Word", "NeedId", "dbo.Need", "Id", cascadeDelete: true);
            DropColumn("dbo.Message", "UserName");
            DropColumn("dbo.Word", "NeedCategory_Id");
            DropColumn("dbo.Word", "PlaceCategory_Id");
            DropTable("dbo.NeedCategory");
            DropTable("dbo.Place");
            DropTable("dbo.PlaceCategory");
            DropTable("dbo.SubCategory");
            DropTable("dbo.Root");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Root",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Root = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        NeedCategory_Id = c.Int(),
                        PlaceCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlaceCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Category_Id = c.Int(nullable: false),
                        SubCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NeedCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Word", "PlaceCategory_Id", c => c.Int());
            AddColumn("dbo.Word", "NeedCategory_Id", c => c.Int());
            AddColumn("dbo.Message", "UserName", c => c.String());
            DropForeignKey("dbo.Word", "NeedId", "dbo.Need");
            DropForeignKey("dbo.Word", "TagId", "dbo.Tag");
            DropForeignKey("dbo.VenueEntityTagEntities", "TagEntity_Id", "dbo.Tag");
            DropForeignKey("dbo.VenueEntityTagEntities", "VenueEntity_Id", "dbo.Venue");
            DropForeignKey("dbo.Message", "UserId", "dbo.User");
            DropIndex("dbo.VenueEntityTagEntities", new[] { "TagEntity_Id" });
            DropIndex("dbo.VenueEntityTagEntities", new[] { "VenueEntity_Id" });
            DropIndex("dbo.Word", new[] { "TagId" });
            DropIndex("dbo.Word", new[] { "NeedId" });
            DropIndex("dbo.Message", new[] { "UserId" });
            AlterColumn("dbo.Word", "NeedId", c => c.Int());
            AlterColumn("dbo.Message", "Message", c => c.String());
            DropColumn("dbo.Word", "TagId");
            DropColumn("dbo.Message", "UserId");
            DropTable("dbo.VenueEntityTagEntities");
            DropTable("dbo.Venue");
            DropTable("dbo.Tag");
            DropTable("dbo.User");
            RenameColumn(table: "dbo.Word", name: "NeedId", newName: "LexicalCategory_Id");
            CreateIndex("dbo.Word", "PlaceCategory_Id");
            CreateIndex("dbo.Word", "NeedCategory_Id");
            CreateIndex("dbo.Word", "LexicalCategory_Id");
            CreateIndex("dbo.SubCategory", "PlaceCategory_Id");
            CreateIndex("dbo.SubCategory", "NeedCategory_Id");
            CreateIndex("dbo.Place", "SubCategory_Id");
            CreateIndex("dbo.Place", "Category_Id");
            AddForeignKey("dbo.Word", "LexicalCategory_Id", "dbo.LexicalCategory", "Id");
            AddForeignKey("dbo.Word", "PlaceCategory_Id", "dbo.PlaceCategory", "Id");
            AddForeignKey("dbo.Word", "NeedCategory_Id", "dbo.NeedCategory", "Id");
            AddForeignKey("dbo.Place", "SubCategory_Id", "dbo.SubCategory", "Id");
            AddForeignKey("dbo.SubCategory", "PlaceCategory_Id", "dbo.PlaceCategory", "Id");
            AddForeignKey("dbo.SubCategory", "NeedCategory_Id", "dbo.NeedCategory", "Id");
            AddForeignKey("dbo.Place", "Category_Id", "dbo.PlaceCategory", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Need", newName: "LexicalCategory");
        }
    }
}

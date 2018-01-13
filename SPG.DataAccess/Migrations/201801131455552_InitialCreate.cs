namespace SPG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LexicalCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Message = c.String(),
                        SendOn = c.DateTime(nullable: false),
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
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Category_Id = c.Int(),
                        SubCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlaceCategory", t => t.Category_Id)
                .ForeignKey("dbo.SubCategory", t => t.SubCategory_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.SubCategory_Id);
            
            CreateTable(
                "dbo.PlaceCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NeedCategory", t => t.NeedCategory_Id)
                .ForeignKey("dbo.PlaceCategory", t => t.PlaceCategory_Id)
                .Index(t => t.NeedCategory_Id)
                .Index(t => t.PlaceCategory_Id);
            
            CreateTable(
                "dbo.Root",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Root = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                        ConfidenceLevel = c.Double(nullable: false),
                        LexicalCategory_Id = c.Int(),
                        NeedCategory_Id = c.Int(),
                        PlaceCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LexicalCategory", t => t.LexicalCategory_Id)
                .ForeignKey("dbo.NeedCategory", t => t.NeedCategory_Id)
                .ForeignKey("dbo.PlaceCategory", t => t.PlaceCategory_Id)
                .Index(t => t.LexicalCategory_Id)
                .Index(t => t.NeedCategory_Id)
                .Index(t => t.PlaceCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Word", "PlaceCategory_Id", "dbo.PlaceCategory");
            DropForeignKey("dbo.Word", "NeedCategory_Id", "dbo.NeedCategory");
            DropForeignKey("dbo.Word", "LexicalCategory_Id", "dbo.LexicalCategory");
            DropForeignKey("dbo.Place", "SubCategory_Id", "dbo.SubCategory");
            DropForeignKey("dbo.SubCategory", "PlaceCategory_Id", "dbo.PlaceCategory");
            DropForeignKey("dbo.SubCategory", "NeedCategory_Id", "dbo.NeedCategory");
            DropForeignKey("dbo.Place", "Category_Id", "dbo.PlaceCategory");
            DropIndex("dbo.Word", new[] { "PlaceCategory_Id" });
            DropIndex("dbo.Word", new[] { "NeedCategory_Id" });
            DropIndex("dbo.Word", new[] { "LexicalCategory_Id" });
            DropIndex("dbo.SubCategory", new[] { "PlaceCategory_Id" });
            DropIndex("dbo.SubCategory", new[] { "NeedCategory_Id" });
            DropIndex("dbo.Place", new[] { "SubCategory_Id" });
            DropIndex("dbo.Place", new[] { "Category_Id" });
            DropTable("dbo.Word");
            DropTable("dbo.Root");
            DropTable("dbo.SubCategory");
            DropTable("dbo.PlaceCategory");
            DropTable("dbo.Place");
            DropTable("dbo.NeedCategory");
            DropTable("dbo.Message");
            DropTable("dbo.LexicalCategory");
        }
    }
}

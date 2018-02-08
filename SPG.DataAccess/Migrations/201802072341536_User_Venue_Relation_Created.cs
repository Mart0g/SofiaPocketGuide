namespace SPG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Venue_Relation_Created : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.VenueEntityTagEntities", newName: "TagEntityVenueEntities");
            DropPrimaryKey("dbo.TagEntityVenueEntities");
            CreateTable(
                "dbo.VenueEntityUserEntities",
                c => new
                    {
                        VenueEntity_Id = c.Int(nullable: false),
                        UserEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VenueEntity_Id, t.UserEntity_Id })
                .ForeignKey("dbo.Venue", t => t.VenueEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserEntity_Id, cascadeDelete: true)
                .Index(t => t.VenueEntity_Id)
                .Index(t => t.UserEntity_Id);
            
            AddPrimaryKey("dbo.TagEntityVenueEntities", new[] { "TagEntity_Id", "VenueEntity_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VenueEntityUserEntities", "UserEntity_Id", "dbo.User");
            DropForeignKey("dbo.VenueEntityUserEntities", "VenueEntity_Id", "dbo.Venue");
            DropIndex("dbo.VenueEntityUserEntities", new[] { "UserEntity_Id" });
            DropIndex("dbo.VenueEntityUserEntities", new[] { "VenueEntity_Id" });
            DropPrimaryKey("dbo.TagEntityVenueEntities");
            DropTable("dbo.VenueEntityUserEntities");
            AddPrimaryKey("dbo.TagEntityVenueEntities", new[] { "VenueEntity_Id", "TagEntity_Id" });
            RenameTable(name: "dbo.TagEntityVenueEntities", newName: "VenueEntityTagEntities");
        }
    }
}

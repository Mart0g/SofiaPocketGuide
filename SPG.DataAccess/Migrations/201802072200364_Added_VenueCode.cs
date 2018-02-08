namespace SPG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_VenueCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venue", "VenueCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venue", "VenueCode");
        }
    }
}

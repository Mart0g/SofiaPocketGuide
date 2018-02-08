namespace SPG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tag_Value_Stringified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tag", "Value", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tag", "Value", c => c.Int(nullable: false));
        }
    }
}

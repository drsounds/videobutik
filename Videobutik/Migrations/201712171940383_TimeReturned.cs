namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeReturned : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.rents", "TimeReturned", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.rents", "TimeReturned");
        }
    }
}

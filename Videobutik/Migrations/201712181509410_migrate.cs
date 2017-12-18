namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.rents", "Start", c => c.DateTime(nullable: false));
            AddColumn("dbo.rents", "End", c => c.DateTime());
            DropColumn("dbo.rents", "Rented");
            DropColumn("dbo.rents", "TimeReturned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.rents", "TimeReturned", c => c.DateTime());
            AddColumn("dbo.rents", "Rented", c => c.DateTime(nullable: false));
            DropColumn("dbo.rents", "End");
            DropColumn("dbo.rents", "Start");
        }
    }
}

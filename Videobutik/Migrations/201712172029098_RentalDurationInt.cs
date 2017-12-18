namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalDurationInt : DbMigration
    {
        public override void Up()
        {
           DropColumn("dbo.rents", "RentalDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.rents", "RentalDuration", c => c.Time(nullable: false, precision: 7));
        }
    }
}

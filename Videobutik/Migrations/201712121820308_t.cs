namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.movies", "RentalDurationTicks", c => c.Long(nullable: false));
            DropColumn("dbo.movies", "RentalDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.movies", "RentalDuration", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.movies", "RentalDurationTicks");
        }
    }
}

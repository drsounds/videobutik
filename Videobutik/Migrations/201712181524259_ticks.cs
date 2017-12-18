namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.movies", "RentalDurationTicks", c => c.Long(nullable: false));
            AddColumn("dbo.rents", "DurationTicks", c => c.Long(nullable: false));
            AddColumn("dbo.rents", "NumberOfDaysOfRent", c => c.Long(nullable: false));
            DropColumn("dbo.movies", "NumberOfDaysInRentalPeriod");
            DropColumn("dbo.rents", "NumberOfDaysInRentalPeriod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.rents", "NumberOfDaysInRentalPeriod", c => c.Int(nullable: false));
            AddColumn("dbo.movies", "NumberOfDaysInRentalPeriod", c => c.Int(nullable: false));
            DropColumn("dbo.rents", "NumberOfDaysOfRent");
            DropColumn("dbo.rents", "DurationTicks");
            DropColumn("dbo.movies", "RentalDurationTicks");
        }
    }
}

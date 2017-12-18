namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalDays : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.movies", "NumberOfDaysInRentalPeriod", c => c.Int(nullable: false));
            AddColumn("dbo.rents", "NumberOfDaysInRentalPeriod", c => c.Int(nullable: false));
            DropColumn("dbo.movies", "RentalDurationTicks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.movies", "RentalDurationTicks", c => c.Long(nullable: false));
            DropColumn("dbo.rents", "NumberOfDaysInRentalPeriod");
            DropColumn("dbo.movies", "NumberOfDaysInRentalPeriod");
        }
    }
}

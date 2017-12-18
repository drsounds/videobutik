namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticks1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.movies", "NumberOfDaysInRentalPeriod", c => c.Long(nullable: false));
            AddColumn("dbo.rents", "NumberOfDaysInRentalPeriod", c => c.Long(nullable: false));
            DropColumn("dbo.rents", "NumberOfDaysOfRent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.rents", "NumberOfDaysOfRent", c => c.Long(nullable: false));
            DropColumn("dbo.rents", "NumberOfDaysInRentalPeriod");
            DropColumn("dbo.movies", "NumberOfDaysInRentalPeriod");
        }
    }
}

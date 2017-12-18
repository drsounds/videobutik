namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateRent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.rents", "Returned", c => c.DateTime());
            AlterColumn("dbo.rents", "End", c => c.DateTime(nullable: false));
            DropColumn("dbo.rents", "DurationTicks");
            DropColumn("dbo.rents", "NumberOfDaysInRentalPeriod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.rents", "NumberOfDaysInRentalPeriod", c => c.Long(nullable: false));
            AddColumn("dbo.rents", "DurationTicks", c => c.Long(nullable: false));
            AlterColumn("dbo.rents", "End", c => c.DateTime());
            DropColumn("dbo.rents", "Returned");
        }
    }
}

namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeReturnedNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.rents", "TimeReturned", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.rents", "TimeReturned", c => c.DateTime(nullable: false));
        }
    }
}

namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.movies", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.movies", "ImageUrl");
        }
    }
}

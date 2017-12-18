namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Keys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.rents", "MovieId", "dbo.movies");
            DropPrimaryKey("dbo.movies");
            DropPrimaryKey("dbo.rents");
            DropColumn("dbo.movies", "Id");
            DropColumn("dbo.rents", "Id");
            AddColumn("dbo.movies", "MovieId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.rents", "RentId", c => c.Int(nullable: false, identity: true));

            AddPrimaryKey("dbo.movies", "MovieId");
            AddPrimaryKey("dbo.rents", "RentId");
            AddForeignKey("dbo.rents", "MovieId", "dbo.movies", "MovieId", cascadeDelete: true);
           }
        
        public override void Down()
        {
            AddColumn("dbo.rents", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.movies", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.rents", "MovieId", "dbo.movies");
            DropPrimaryKey("dbo.rents");
            DropPrimaryKey("dbo.movies");
            DropColumn("dbo.rents", "RentId");
            DropColumn("dbo.movies", "MovieId");
            AddPrimaryKey("dbo.rents", "Id");
            AddPrimaryKey("dbo.movies", "Id");
            AddForeignKey("dbo.rents", "MovieId", "dbo.movies", "Id", cascadeDelete: true);
        }
    }
}

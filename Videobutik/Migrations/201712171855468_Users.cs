namespace Videobutik.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.rents", new[] { "User_Id" });
            DropColumn("dbo.rents", "UserId");
            RenameColumn(table: "dbo.rents", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.rents", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.rents", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.rents", new[] { "UserId" });
            AlterColumn("dbo.rents", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.rents", name: "UserId", newName: "User_Id");
            AddColumn("dbo.rents", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.rents", "User_Id");
        }
    }
}

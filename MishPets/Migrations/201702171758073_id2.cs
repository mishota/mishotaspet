namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.NewHomeContracts", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.OverexposureContracts", new[] { "ApplicationUser_Id1" });
            DropColumn("dbo.NewHomeContracts", "ApplicationUser_Id");
            DropColumn("dbo.OverexposureContracts", "ApplicationUser_Id");
            RenameColumn(table: "dbo.NewHomeContracts", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.OverexposureContracts", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            AlterColumn("dbo.NewHomeContracts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.OverexposureContracts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.NewHomeContracts", "ApplicationUser_Id");
            CreateIndex("dbo.OverexposureContracts", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.OverexposureContracts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.NewHomeContracts", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.OverexposureContracts", "ApplicationUser_Id", c => c.String());
            AlterColumn("dbo.NewHomeContracts", "ApplicationUser_Id", c => c.String());
            RenameColumn(table: "dbo.OverexposureContracts", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            RenameColumn(table: "dbo.NewHomeContracts", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            AddColumn("dbo.OverexposureContracts", "ApplicationUser_Id", c => c.String());
            AddColumn("dbo.NewHomeContracts", "ApplicationUser_Id", c => c.String());
            CreateIndex("dbo.OverexposureContracts", "ApplicationUser_Id1");
            CreateIndex("dbo.NewHomeContracts", "ApplicationUser_Id1");
        }
    }
}

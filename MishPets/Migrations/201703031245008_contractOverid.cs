namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contractOverid : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.OverexposureContracts", new[] { "ApplicationUser_Id1" });
            //DropColumn("dbo.OverexposureContracts", "ApplicationUser_Id");
            //RenameColumn(table: "dbo.OverexposureContracts", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            //AlterColumn("dbo.OverexposureContracts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            //CreateIndex("dbo.OverexposureContracts", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.OverexposureContracts", new[] { "ApplicationUser_Id" });
            //AlterColumn("dbo.OverexposureContracts", "ApplicationUser_Id", c => c.String());
            //RenameColumn(table: "dbo.OverexposureContracts", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            //AddColumn("dbo.OverexposureContracts", "ApplicationUser_Id", c => c.String());
            //CreateIndex("dbo.OverexposureContracts", "ApplicationUser_Id1");
        }
    }
}

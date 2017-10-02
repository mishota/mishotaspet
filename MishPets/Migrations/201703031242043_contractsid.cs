namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contractsid : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.OverexposureContracts", "ApplicationUser_Id", "dbo.AspNetUsers");
            //DropForeignKey("dbo.NewHomeContracts", "ApplicationUser_Id", "dbo.AspNetUsers");
            //DropIndex("dbo.OverexposureContracts", new[] { "ApplicationUser_Id" });
            //DropIndex("dbo.NewHomeContracts", new[] { "ApplicationUser_Id" });
            //AddColumn("dbo.OverexposureContracts", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            //AddColumn("dbo.NewHomeContracts", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            //AlterColumn("dbo.OverexposureContracts", "ApplicationUser_Id", c => c.String());
            //AlterColumn("dbo.NewHomeContracts", "ApplicationUser_Id", c => c.String());
            //CreateIndex("dbo.OverexposureContracts", "ApplicationUser_Id1");
            //CreateIndex("dbo.NewHomeContracts", "ApplicationUser_Id1");
            //AddForeignKey("dbo.OverexposureContracts", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            //AddForeignKey("dbo.NewHomeContracts", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.NewHomeContracts", "ApplicationUser_Id1", "dbo.AspNetUsers");
            //DropForeignKey("dbo.OverexposureContracts", "ApplicationUser_Id1", "dbo.AspNetUsers");
            //DropIndex("dbo.NewHomeContracts", new[] { "ApplicationUser_Id1" });
            //DropIndex("dbo.OverexposureContracts", new[] { "ApplicationUser_Id1" });
            //AlterColumn("dbo.NewHomeContracts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            //AlterColumn("dbo.OverexposureContracts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            //DropColumn("dbo.NewHomeContracts", "ApplicationUser_Id1");
            //DropColumn("dbo.OverexposureContracts", "ApplicationUser_Id1");
            //CreateIndex("dbo.NewHomeContracts", "ApplicationUser_Id");
            //CreateIndex("dbo.OverexposureContracts", "ApplicationUser_Id");
            //AddForeignKey("dbo.NewHomeContracts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            //AddForeignKey("dbo.OverexposureContracts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

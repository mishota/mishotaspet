namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NewHomeContracts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OverexposureContracts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.NewHomeContracts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.OverexposureContracts", new[] { "ApplicationUser_Id" });
            DropPrimaryKey("dbo.NewHomeContracts");
            DropPrimaryKey("dbo.OverexposureContracts");
            AddColumn("dbo.NewHomeContracts", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.OverexposureContracts", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.NewHomeContracts", "NewHomeContractId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.NewHomeContracts", "ApplicationUser_Id", c => c.String());
            AlterColumn("dbo.OverexposureContracts", "OverexposureContractId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.OverexposureContracts", "ApplicationUser_Id", c => c.String());
            AddPrimaryKey("dbo.NewHomeContracts", "NewHomeContractId");
            AddPrimaryKey("dbo.OverexposureContracts", "OverexposureContractId");
            CreateIndex("dbo.NewHomeContracts", "ApplicationUser_Id1");
            CreateIndex("dbo.OverexposureContracts", "ApplicationUser_Id1");
            AddForeignKey("dbo.NewHomeContracts", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.OverexposureContracts", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.NewHomeContracts", "Id");
            DropColumn("dbo.OverexposureContracts", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OverexposureContracts", "Id", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.NewHomeContracts", "Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.OverexposureContracts", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.NewHomeContracts", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.OverexposureContracts", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.NewHomeContracts", new[] { "ApplicationUser_Id1" });
            DropPrimaryKey("dbo.OverexposureContracts");
            DropPrimaryKey("dbo.NewHomeContracts");
            AlterColumn("dbo.OverexposureContracts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.OverexposureContracts", "OverexposureContractId", c => c.Int(nullable: false));
            AlterColumn("dbo.NewHomeContracts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.NewHomeContracts", "NewHomeContractId", c => c.Int(nullable: false));
            DropColumn("dbo.OverexposureContracts", "ApplicationUser_Id1");
            DropColumn("dbo.NewHomeContracts", "ApplicationUser_Id1");
            AddPrimaryKey("dbo.OverexposureContracts", "Id");
            AddPrimaryKey("dbo.NewHomeContracts", "Id");
            CreateIndex("dbo.OverexposureContracts", "ApplicationUser_Id");
            CreateIndex("dbo.NewHomeContracts", "ApplicationUser_Id");
            AddForeignKey("dbo.OverexposureContracts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.NewHomeContracts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid1 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Invoices", "OverexposureContractId", "dbo.OverexposureContracts");
            //DropForeignKey("dbo.Payments", "OverexposureContractId", "dbo.OverexposureContracts");
            //DropIndex("dbo.Invoices", new[] { "OverexposureContractId" });
            //DropIndex("dbo.Payments", new[] { "OverexposureContractId" });
            //DropPrimaryKey("dbo.OverexposureContracts");
            //AddColumn("dbo.Invoices", "OverexposureContracts_Id", c => c.String(maxLength: 128));
            //AddColumn("dbo.OverexposureContracts", "Id", c => c.String(nullable: false, maxLength: 128));
            //AddColumn("dbo.Payments", "OverexposureContracts_Id", c => c.String(maxLength: 128));
            //AlterColumn("dbo.OverexposureContracts", "OverexposureContractId", c => c.Int(nullable: false));
            //AddPrimaryKey("dbo.OverexposureContracts", "Id");
            //CreateIndex("dbo.Invoices", "OverexposureContracts_Id");
            //CreateIndex("dbo.Payments", "OverexposureContracts_Id");
            //AddForeignKey("dbo.Invoices", "OverexposureContracts_Id", "dbo.OverexposureContracts", "Id");
            //AddForeignKey("dbo.Payments", "OverexposureContracts_Id", "dbo.OverexposureContracts", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Payments", "OverexposureContracts_Id", "dbo.OverexposureContracts");
            //DropForeignKey("dbo.Invoices", "OverexposureContracts_Id", "dbo.OverexposureContracts");
            //DropIndex("dbo.Payments", new[] { "OverexposureContracts_Id" });
            //DropIndex("dbo.Invoices", new[] { "OverexposureContracts_Id" });
            //DropPrimaryKey("dbo.OverexposureContracts");
            //AlterColumn("dbo.OverexposureContracts", "OverexposureContractId", c => c.Int(nullable: false, identity: true));
            //DropColumn("dbo.Payments", "OverexposureContracts_Id");
            //DropColumn("dbo.OverexposureContracts", "Id");
            //DropColumn("dbo.Invoices", "OverexposureContracts_Id");
            //AddPrimaryKey("dbo.OverexposureContracts", "OverexposureContractId");
            //CreateIndex("dbo.Payments", "OverexposureContractId");
            //CreateIndex("dbo.Invoices", "OverexposureContractId");
            //AddForeignKey("dbo.Payments", "OverexposureContractId", "dbo.OverexposureContracts", "OverexposureContractId", cascadeDelete: true);
            //AddForeignKey("dbo.Invoices", "OverexposureContractId", "dbo.OverexposureContracts", "OverexposureContractId", cascadeDelete: true);
        }
    }
}

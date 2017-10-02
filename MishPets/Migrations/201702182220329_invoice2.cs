namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoice2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Invoices", name: "OverexposureContract_OverexposureContractId", newName: "OverexposureContracts_OverexposureContractId");
            RenameIndex(table: "dbo.Invoices", name: "IX_OverexposureContract_OverexposureContractId", newName: "IX_OverexposureContracts_OverexposureContractId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Invoices", name: "IX_OverexposureContracts_OverexposureContractId", newName: "IX_OverexposureContract_OverexposureContractId");
            RenameColumn(table: "dbo.Invoices", name: "OverexposureContracts_OverexposureContractId", newName: "OverexposureContract_OverexposureContractId");
        }
    }
}

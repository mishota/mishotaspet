namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identityOver : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OverexposureContracts", "OverexposureContractId", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OverexposureContracts", "OverexposureContractId", c => c.Int(nullable: false));
        }
    }
}

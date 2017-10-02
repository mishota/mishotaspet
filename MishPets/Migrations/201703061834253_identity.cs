namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NewHomeContracts", "NewHomeContractId", c => c.Int(nullable: false, identity: true));
        }


        public override void Down()
        {
            AlterColumn("dbo.NewHomeContracts", "NewHomeContractId", c => c.Int(nullable: false));
        }
    }
}

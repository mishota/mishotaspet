namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newuserids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String());
            AddColumn("dbo.OverexposureContracts", "IdUserForOverexp", c => c.String());
            AddColumn("dbo.NewHomeContracts", "IdUserForNewHome", c => c.String());
            DropColumn("dbo.AspNetUsers", "Fhone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Fhone", c => c.String());
            DropColumn("dbo.NewHomeContracts", "IdUserForNewHome");
            DropColumn("dbo.OverexposureContracts", "IdUserForOverexp");
            DropColumn("dbo.AspNetUsers", "Phone");
        }
    }
}

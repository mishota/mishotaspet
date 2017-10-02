namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.NewHomeContracts", "ApplUser_Id");
        }
        
        public override void Down()
        {
           // AddColumn("dbo.NewHomeContracts", "ApplUser_Id", c => c.String());
        }
    }
}

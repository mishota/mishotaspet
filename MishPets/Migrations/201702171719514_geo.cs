namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class geo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "GeoLong", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "GeoLat", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GeoLat");
            DropColumn("dbo.AspNetUsers", "GeoLong");
        }
    }
}

namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class overUserId : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.NewHomeContracts", new[] { "ApplicationUser_Id1" });
            //DropColumn("dbo.NewHomeContracts", "ApplicationUser_Id");
            //RenameColumn(table: "dbo.NewHomeContracts", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            //AddColumn("dbo.NewHomeContracts", "ApplUser_Id", c => c.String());
            //AlterColumn("dbo.NewHomeContracts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            //CreateIndex("dbo.NewHomeContracts", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.NewHomeContracts", new[] { "ApplicationUser_Id" });
            //AlterColumn("dbo.NewHomeContracts", "ApplicationUser_Id", c => c.String());
            //DropColumn("dbo.NewHomeContracts", "ApplUser_Id");
            //RenameColumn(table: "dbo.NewHomeContracts", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            //AddColumn("dbo.NewHomeContracts", "ApplicationUser_Id", c => c.String());
            //CreateIndex("dbo.NewHomeContracts", "ApplicationUser_Id1");
        }
    }
}

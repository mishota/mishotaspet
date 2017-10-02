namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogPosts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BlogPosts", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.BlogPosts", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.BlogPosts", "ApplicationUser_Id", c => c.String());
            CreateIndex("dbo.BlogPosts", "ApplicationUser_Id1");
            AddForeignKey("dbo.BlogPosts", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.BlogPosts", new[] { "ApplicationUser_Id1" });
            AlterColumn("dbo.BlogPosts", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.BlogPosts", "ApplicationUser_Id1");
            CreateIndex("dbo.BlogPosts", "ApplicationUser_Id");
            AddForeignKey("dbo.BlogPosts", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

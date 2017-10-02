namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fhone : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BlogPosts");
            AddColumn("dbo.AspNetUsers", "Fhone", c => c.String());
            AlterColumn("dbo.BlogPosts", "BlogPostId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BlogPosts", "BlogPostId");
            DropColumn("dbo.BlogPosts", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogPosts", "Id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.BlogPosts");
            AlterColumn("dbo.BlogPosts", "BlogPostId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Fhone");
            AddPrimaryKey("dbo.BlogPosts", "Id");
        }
    }
}

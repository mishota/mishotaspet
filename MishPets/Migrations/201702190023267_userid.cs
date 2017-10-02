namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BlogPosts");
            AddColumn("dbo.BlogPosts", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.BlogPosts", "BlogPostId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.BlogPosts", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BlogPosts");
            AlterColumn("dbo.BlogPosts", "BlogPostId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.BlogPosts", "Id");
            AddPrimaryKey("dbo.BlogPosts", "BlogPostId");
        }
    }
}

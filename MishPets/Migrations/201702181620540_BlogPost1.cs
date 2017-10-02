namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogPost1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        BlogPostId = c.Int(nullable: false, identity: true),
                        DatetimeBlogPost = c.DateTime(nullable: false),
                        TextOfPost = c.String(),
                        ImagePost = c.Binary(),
                        ImagePostMimeType = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BlogPostId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.BlogPosts", new[] { "ApplicationUser_Id" });
            DropTable("dbo.BlogPosts");
        }
    }
}

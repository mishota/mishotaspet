namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ByteString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pets", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "ImageMimeType", c => c.Binary());
        }
    }
}

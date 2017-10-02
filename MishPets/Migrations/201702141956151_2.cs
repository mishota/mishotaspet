namespace MishPets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KindOfPets",
                c => new
                    {
                        KindOfPetId = c.Int(nullable: false, identity: true),
                        Kind = c.String(),
                    })
                .PrimaryKey(t => t.KindOfPetId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        PetId = c.Int(nullable: false, identity: true),
                        KindOfPetId = c.Int(nullable: false),
                        NickName = c.String(),
                        Age = c.Int(nullable: false),
                        DescriptionOfPet = c.String(),
                        FlagMale = c.Int(nullable: false),
                        StatusOfPet = c.String(),
                        ImagePet = c.Binary(),
                        ImageMimeType = c.Binary(),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.KindOfPets", t => t.KindOfPetId, cascadeDelete: true)
                .Index(t => t.KindOfPetId);
            
            CreateTable(
                "dbo.NewHomeContracts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NewHomeContractId = c.Int(nullable: false),
                        PetId = c.Int(nullable: false),
                        DateHomeStart = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.OverexposureContracts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OverexposureContractId = c.Int(nullable: false),
                        PetId = c.Int(nullable: false),
                        DateOverexpStart = c.DateTime(nullable: false),
                        DateOverexpEnd = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OverexposureContracts", "PetId", "dbo.Pets");
            DropForeignKey("dbo.OverexposureContracts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.NewHomeContracts", "PetId", "dbo.Pets");
            DropForeignKey("dbo.NewHomeContracts", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pets", "KindOfPetId", "dbo.KindOfPets");
            DropIndex("dbo.OverexposureContracts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.OverexposureContracts", new[] { "PetId" });
            DropIndex("dbo.NewHomeContracts", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.NewHomeContracts", new[] { "PetId" });
            DropIndex("dbo.Pets", new[] { "KindOfPetId" });
            DropTable("dbo.OverexposureContracts");
            DropTable("dbo.NewHomeContracts");
            DropTable("dbo.Pets");
            DropTable("dbo.KindOfPets");
        }
    }
}

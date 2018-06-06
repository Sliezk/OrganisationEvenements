namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifTheme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        CodeBinaire = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Evenements", "Image_ID", c => c.Guid());
            CreateIndex("dbo.Evenements", "Image_ID");
            AddForeignKey("dbo.Evenements", "Image_ID", "dbo.Images", "ID");
            DropColumn("dbo.Evenements", "Image");
            DropColumn("dbo.Evenements", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evenements", "ImagePath", c => c.String());
            AddColumn("dbo.Evenements", "Image", c => c.Binary());
            DropForeignKey("dbo.Evenements", "Image_ID", "dbo.Images");
            DropIndex("dbo.Evenements", new[] { "Image_ID" });
            DropColumn("dbo.Evenements", "Image_ID");
            DropTable("dbo.Images");
        }
    }
}

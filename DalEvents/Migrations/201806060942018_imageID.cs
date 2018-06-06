namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Evenements", "Image_ID", "dbo.Images");
            DropIndex("dbo.Evenements", new[] { "Image_ID" });
            RenameColumn(table: "dbo.Evenements", name: "Image_ID", newName: "ImageID");
            AlterColumn("dbo.Evenements", "ImageID", c => c.Guid(nullable: true));
            CreateIndex("dbo.Evenements", "ImageID");
            AddForeignKey("dbo.Evenements", "ImageID", "dbo.Images", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evenements", "ImageID", "dbo.Images");
            DropIndex("dbo.Evenements", new[] { "ImageID" });
            AlterColumn("dbo.Evenements", "ImageID", c => c.Guid());
            RenameColumn(table: "dbo.Evenements", name: "ImageID", newName: "Image_ID");
            CreateIndex("dbo.Evenements", "Image_ID");
            AddForeignKey("dbo.Evenements", "Image_ID", "dbo.Images", "ID");
        }
    }
}

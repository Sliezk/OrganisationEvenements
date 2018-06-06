namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retraitImageID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Evenements", "ImageID", "dbo.Images");
            DropIndex("dbo.Evenements", new[] { "ImageID" });
            RenameColumn(table: "dbo.Evenements", name: "ImageID", newName: "Image_ID");
            AlterColumn("dbo.Evenements", "Image_ID", c => c.Guid());
            CreateIndex("dbo.Evenements", "Image_ID");
            AddForeignKey("dbo.Evenements", "Image_ID", "dbo.Images", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evenements", "Image_ID", "dbo.Images");
            DropIndex("dbo.Evenements", new[] { "Image_ID" });
            AlterColumn("dbo.Evenements", "Image_ID", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Evenements", name: "Image_ID", newName: "ImageID");
            CreateIndex("dbo.Evenements", "ImageID");
            AddForeignKey("dbo.Evenements", "ImageID", "dbo.Images", "ID", cascadeDelete: true);
        }
    }
}

namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Evenements", "ImageID", "dbo.Images");
            DropIndex("dbo.Evenements", new[] { "ImageID" });
            AddColumn("dbo.Images", "Fichier", c => c.String());
            DropColumn("dbo.Evenements", "ImageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evenements", "ImageID", c => c.Guid(nullable: false));
            DropColumn("dbo.Images", "Fichier");
            CreateIndex("dbo.Evenements", "ImageID");
            AddForeignKey("dbo.Evenements", "ImageID", "dbo.Images", "ID", cascadeDelete: true);
        }
    }
}

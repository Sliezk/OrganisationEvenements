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
            RenameColumn(table: "dbo.Images", name: "ImageID", newName: "Evenement_ID");
            AddColumn("dbo.Images", "Fichier", c => c.String());
            CreateIndex("dbo.Images", "Evenement_ID");
            AddForeignKey("dbo.Images", "Evenement_ID", "dbo.Evenements", "ID");
            DropColumn("dbo.Evenements", "ImageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evenements", "ImageID", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Images", "Evenement_ID", "dbo.Evenements");
            DropIndex("dbo.Images", new[] { "Evenement_ID" });
            DropColumn("dbo.Images", "Fichier");
            RenameColumn(table: "dbo.Images", name: "Evenement_ID", newName: "ImageID");
            CreateIndex("dbo.Evenements", "ImageID");
            AddForeignKey("dbo.Evenements", "ImageID", "dbo.Images", "ID", cascadeDelete: true);
        }
    }
}

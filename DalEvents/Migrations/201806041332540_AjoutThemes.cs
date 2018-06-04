namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutThemes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Themes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Evenements", "Theme_ID", c => c.Guid());
            CreateIndex("dbo.Evenements", "Theme_ID");
            AddForeignKey("dbo.Evenements", "Theme_ID", "dbo.Themes", "ID");
            DropColumn("dbo.Evenements", "Theme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evenements", "Theme", c => c.String());
            DropForeignKey("dbo.Evenements", "Theme_ID", "dbo.Themes");
            DropIndex("dbo.Evenements", new[] { "Theme_ID" });
            DropColumn("dbo.Evenements", "Theme_ID");
            DropTable("dbo.Themes");
        }
    }
}

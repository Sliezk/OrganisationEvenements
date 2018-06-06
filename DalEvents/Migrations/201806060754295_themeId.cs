namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Evenements", "Theme_ID", "dbo.Themes");
            DropIndex("dbo.Evenements", new[] { "Theme_ID" });
            RenameColumn(table: "dbo.Evenements", name: "Theme_ID", newName: "ThemeID");
            AlterColumn("dbo.Evenements", "ThemeID", c => c.Guid(nullable: true));
            CreateIndex("dbo.Evenements", "ThemeID");
            AddForeignKey("dbo.Evenements", "ThemeID", "dbo.Themes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evenements", "ThemeID", "dbo.Themes");
            DropIndex("dbo.Evenements", new[] { "ThemeID" });
            AlterColumn("dbo.Evenements", "ThemeID", c => c.Guid());
            RenameColumn(table: "dbo.Evenements", name: "ThemeID", newName: "Theme_ID");
            CreateIndex("dbo.Evenements", "Theme_ID");
            AddForeignKey("dbo.Evenements", "Theme_ID", "dbo.Themes", "ID");
        }
    }
}

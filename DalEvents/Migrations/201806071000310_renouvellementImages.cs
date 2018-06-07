namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renouvellementImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Evenement_ID", c => c.Guid());
            CreateIndex("dbo.Images", "Evenement_ID");
            AddForeignKey("dbo.Images", "Evenement_ID", "dbo.Evenements", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Evenement_ID", "dbo.Evenements");
            DropIndex("dbo.Images", new[] { "Evenement_ID" });
            DropColumn("dbo.Images", "Evenement_ID");
        }
    }
}

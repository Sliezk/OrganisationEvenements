namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Path", c => c.String());
            DropColumn("dbo.Images", "CodeBinaire");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "CodeBinaire", c => c.Binary());
            DropColumn("dbo.Images", "Path");
        }
    }
}

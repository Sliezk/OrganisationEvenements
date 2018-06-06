namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "ImagePath", c => c.String());
            AlterColumn("dbo.Evenements", "Image", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Evenements", "Image", c => c.String());
            DropColumn("dbo.Evenements", "ImagePath");
        }
    }
}

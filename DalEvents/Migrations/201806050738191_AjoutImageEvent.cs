namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutImageEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evenements", "Image");
        }
    }
}

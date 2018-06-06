namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutImageByte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Evenements", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Evenements", "Image", c => c.Byte(nullable: false));
        }
    }
}

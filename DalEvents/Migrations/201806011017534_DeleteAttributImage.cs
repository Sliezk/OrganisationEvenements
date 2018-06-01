namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAttributImage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Evenements", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evenements", "Image", c => c.String());
        }
    }
}

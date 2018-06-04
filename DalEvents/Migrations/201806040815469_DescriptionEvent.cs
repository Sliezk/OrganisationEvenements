namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evenements", "Description");
        }
    }
}

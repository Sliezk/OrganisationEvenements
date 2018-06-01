namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajoutNomEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evenements", "Nom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evenements", "Nom");
        }
    }
}

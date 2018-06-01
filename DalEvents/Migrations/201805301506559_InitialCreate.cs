namespace DalEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evenements",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Lieu = c.String(),
                        Date = c.DateTime(nullable: false),
                        Duree = c.Int(nullable: false),
                        Theme = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Evenements");
        }
    }
}

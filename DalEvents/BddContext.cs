namespace DalEvents
{
    using BoEvents;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class BddContext : IdentityDbContext<ApplicationUser>
    {
        public BddContext()
            : base("name=BddContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BddContext, DalEvents.Migrations.Configuration>());
        }

        public static BddContext Create()
        {
            return new BddContext();
        }

        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
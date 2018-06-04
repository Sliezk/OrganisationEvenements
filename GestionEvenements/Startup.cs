using DalEvents;
using GestionEvenements.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionEvenements.Startup))]
namespace GestionEvenements
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            CreateRolesAndUsers();
            ConfigureAuth(app);
        }

        private void CreateRolesAndUsers()
        {
            using (BddContext contexte = new BddContext())
            {
                //on récupère les managers de roles et users
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(contexte));
                var userManager = new UserManager<DalEvents.ApplicationUser>(new UserStore<DalEvents.ApplicationUser>(contexte));



                ////Here we create a Admin super user who will maintain the website

                //var user = new DalEvents.ApplicationUser();
                //user.UserName = "admin@gmail.com";
                //user.Email = "admin@gmail.com";

                //string userPWD = "Pa$$w0rd";

                //var chkUser = userManager.Create(user, userPWD);

                ////Add default User to Role Admin
                //if (chkUser.Succeeded)
                //{
                //    var result1 = userManager.AddToRole(user.Id, "Admin");

                //}

                //on va créer des nouveaux roles : on vérifie s'ils existent déjà
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                }

                if (!roleManager.RoleExists("Utilisateur"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Utilisateur";
                    roleManager.Create(role);
                }
            }
        }

    }
}

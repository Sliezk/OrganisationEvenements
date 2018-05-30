using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionEvenements.Startup))]
namespace GestionEvenements
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

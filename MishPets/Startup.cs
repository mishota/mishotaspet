using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MishPets.Startup))]
namespace MishPets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

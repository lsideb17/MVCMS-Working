using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCModuleStarter.Startup))]
namespace MVCModuleStarter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

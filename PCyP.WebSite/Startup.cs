using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PCyP.WebSite.Startup))]
namespace PCyP.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

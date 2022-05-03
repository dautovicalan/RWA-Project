using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PublicSite.Startup))]
namespace PublicSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

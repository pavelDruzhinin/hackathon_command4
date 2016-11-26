using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialWeb.Startup))]
namespace SocialWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

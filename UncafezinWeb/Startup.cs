using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UncafezinWeb.Startup))]
namespace UncafezinWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

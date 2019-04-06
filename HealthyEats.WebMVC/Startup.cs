using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HealthyEats.WebMVC.Startup))]
namespace HealthyEats.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VetClinic.Startup))]
namespace VetClinic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

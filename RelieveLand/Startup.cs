using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RelieveLand.Startup))]
namespace RelieveLand
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

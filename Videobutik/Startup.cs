using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Videobutik.Startup))]
namespace Videobutik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

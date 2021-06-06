using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Warp_Derick.Startup))]
namespace Warp_Derick
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

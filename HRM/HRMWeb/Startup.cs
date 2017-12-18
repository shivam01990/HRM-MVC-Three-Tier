using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRMWeb.Startup))]
namespace HRMWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

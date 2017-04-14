using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TST.Startup))]
namespace TST
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

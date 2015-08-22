using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManteqCodeTest.Startup))]
namespace ManteqCodeTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

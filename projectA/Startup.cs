using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projectA.Startup))]
namespace projectA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

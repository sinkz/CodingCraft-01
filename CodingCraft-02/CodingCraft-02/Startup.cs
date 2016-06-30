using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodingCraft_02.Startup))]
namespace CodingCraft_02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

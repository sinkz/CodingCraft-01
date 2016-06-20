using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodingCraft01.Startup))]
namespace CodingCraft01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

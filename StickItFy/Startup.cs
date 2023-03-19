using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StickItFy.Startup))]
namespace StickItFy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

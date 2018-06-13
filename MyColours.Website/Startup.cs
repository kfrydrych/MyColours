using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyColours.Website.Startup))]
namespace MyColours.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

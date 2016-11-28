using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealStoriesExposed.Startup))]
namespace RealStoriesExposed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

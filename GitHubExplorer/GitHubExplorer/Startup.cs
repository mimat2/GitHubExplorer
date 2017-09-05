using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GitHubExplorer.Startup))]
namespace GitHubExplorer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(project_dotnet.Startup))]
namespace project_dotnet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

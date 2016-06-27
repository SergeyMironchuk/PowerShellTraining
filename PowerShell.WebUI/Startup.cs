using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PowerShell.WebUI.Startup))]
namespace PowerShell.WebUI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

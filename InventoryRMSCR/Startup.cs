using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventoryRMSCR.Startup))]
namespace InventoryRMSCR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

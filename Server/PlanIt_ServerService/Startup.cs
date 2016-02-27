using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PlanIt_ServerService.Startup))]

namespace PlanIt_ServerService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}
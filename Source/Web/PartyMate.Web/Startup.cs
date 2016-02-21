using Microsoft.Owin;
using Owin;

using PartyMate.Web.Infrastructure.Mapping;

[assembly: OwinStartupAttribute(typeof(PartyMate.Web.Startup))]
namespace PartyMate.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //DatabaseConfig.Initialize();
            ConfigureAuth(app);
        }
    }
}

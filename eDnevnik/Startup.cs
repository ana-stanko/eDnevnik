using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eDnevnik.Startup))]
namespace eDnevnik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KlsFinanceApp.Startup))]
namespace KlsFinanceApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

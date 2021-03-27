using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nagarro.BookEventManagement.Startup))]
namespace Nagarro.BookEventManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1.BookDonation.Web.Startup))]
namespace _1.BookDonation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

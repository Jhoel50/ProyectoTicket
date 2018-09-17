using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketPeru.Startup))]
namespace TicketPeru
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
       
        }
    }
}

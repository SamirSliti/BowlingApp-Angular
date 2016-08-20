using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BowlingApp.Startup))]
namespace BowlingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           

        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystemLaptop.Startup))]
namespace SystemLaptop
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieSystem.MVC.Startup))]
namespace MovieSystem.MVC
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}

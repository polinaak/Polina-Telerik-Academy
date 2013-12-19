using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HambergiteConquistador.Startup))]
namespace HambergiteConquistador
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Javascript.Startup))]
namespace Javascript
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

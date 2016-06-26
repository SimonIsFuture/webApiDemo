using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(homeWork.Startup))]
namespace homeWork
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

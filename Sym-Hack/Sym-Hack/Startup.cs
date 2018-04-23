using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sym_Hack.Startup))]
namespace Sym_Hack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

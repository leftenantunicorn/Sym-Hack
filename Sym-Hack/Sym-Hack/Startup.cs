using System.Data.Entity;
using Microsoft.Owin;
using MySql.Data.Entity;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sym_Hack.Startup))]
namespace Sym_Hack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            ConfigureAuth(app);
            CreateRolesandUsers();
        }
    }
}

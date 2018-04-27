using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sym_Hack
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            if (bool.Parse(ConfigurationManager.AppSettings["MigrateDatabaseToLatestVersion"]))
            {
                var configuration = new Sym_Hack.Domain.Migrations.Configuration
                {
                    TargetDatabase = new DbConnectionInfo(
                    "server=127.0.0.1;userid=azure;password=6#vWHD_$;database=localdb;Port=53025;",
                    "MySql.Data.MySqlClient")
                };
                var migrator = new DbMigrator(configuration);
                migrator.Update();
            }
        }
    }
}

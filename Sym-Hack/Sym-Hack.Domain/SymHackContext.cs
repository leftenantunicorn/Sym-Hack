using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using Sym_Hack.Domain.Entities;

namespace Sym_Hack.Domain
{
    // Code-Based Configuration and Dependency resolution  
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SymHackContext : IdentityDbContext<SymHackUser>
    {   
        public SymHackContext(): base("symhackcontext", throwIfV1Schema: false) { }

        public static SymHackContext Create()
        {
            return new SymHackContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

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

            #region Fix asp.net identity 2.0 tables under MySQL
            // Explanations: primary keys can easily get too long for MySQL's 
            // (InnoDB's) stupid 767 bytes limit.
            // With the two following lines we rewrite the generation to keep
            // those columns "short" enough
            modelBuilder.Entity<IdentityRole>()
                .Property(c => c.Name)
                .HasMaxLength(128)
                .IsRequired();

            // We have to declare the table name here, otherwise IdentityUser 
            // will be created
            modelBuilder.Entity<SymHackUser>()
                .ToTable("AspNetUsers")
                .Property(c => c.UserName)
                .HasMaxLength(128)
                .IsRequired();
            #endregion
        }
    }
}

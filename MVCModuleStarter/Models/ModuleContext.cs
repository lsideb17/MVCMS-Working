using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Diagnostics;

namespace MVCModuleStarter.Models
{
    public class ModuleContext : DbContext
    {
        public ModuleContext() : base("MVCModules.ModuleContext") { }

        public DbSet<Module> Modules { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
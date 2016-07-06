using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCModuleStarter.Models;

namespace MVCModuleStarter.ViewModels
{
    public class ModulesViewModel
    {
        public IEnumerable<Module> modules { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
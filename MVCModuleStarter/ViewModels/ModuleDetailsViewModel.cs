using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCModuleStarter.Models;

namespace MVCModuleStarter.ViewModels
{
    public class ModuleDetailsViewModel
    {
        public Module module { get; set; }
        public IEnumerable<Module> othermodules { get; set; }
        public Keyword keyword { get; set; }
        public IEnumerable<Keyword> allkeywords { get; set; }
    }
}
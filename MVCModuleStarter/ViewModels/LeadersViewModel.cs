using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCModuleStarter.Models;
//using System.Web.Mvc;

namespace MVCModuleStarter.ViewModels
{
    public class LeadersViewModel
    {
        public Module module { get; set; }
        public IEnumerable<ModuleLeader> moduleleaders { get; set; }
        public IEnumerable<Module> leadersmodules { get; set; }
    }
}
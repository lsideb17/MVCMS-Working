using System.Collections.Generic;
using MVCModuleStarter.Models;

namespace MVCModuleStarter.ViewModels
{
    public class HomeViewModel
    {
        //public IEnumerable<Module> modules { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Module> randommodules { get; set; }
    }
}
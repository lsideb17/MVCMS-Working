using MVCModuleStarter.Helpers;
using MVCModuleStarter.Models;
using MVCModuleStarter.Repository;
using MVCModuleStarter.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCModuleStarter.Controllers
{
    public class HomeController : Controller
    {
        private ModulesRepository repository = new ModulesRepository(new ModuleContext());

        public ActionResult Index(int? page)
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            

          
            
             const int pageSize = 12;

            ModulesViewModel modulesViewModel = new ModulesViewModel();

            IQueryable<Category> categories = repository.GetCategories();
            homeViewModel.categories = categories;

            IQueryable<Module> randommodules = repository.GetRandomModules();
            //homeViewModel.randommodules = randommodules;
            Func<Module, IComparable> func = null;
            func = (Module a) => a.ModuleId;

            var paginatedModules = new PaginatedList<Module>(randommodules, page ?? 0, func, pageSize);
            homeViewModel.randommodules = paginatedModules;


            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
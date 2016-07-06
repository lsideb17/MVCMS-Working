using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVCModuleStarter.Models;
using MVCModuleStarter.Repository;
using MVCModuleStarter.ViewModels;
using MVCModuleStarter.Helpers;
using System.Collections.Generic;
using System;


namespace MVCModuleStarter.Controllers
{
    public class ModulesController : Controller
    {
        private ModulesRepository repository = new ModulesRepository(new ModuleContext());

      
        
        // GET: Modules
        public ActionResult Index(int? page)
        {
            const int pageSize = 12;

            ModulesViewModel modulesViewModel = new ModulesViewModel();

            IQueryable<Category> categories = repository.GetCategories();
            modulesViewModel.categories = categories;

            IQueryable<Module> modules = repository.GetAllModules();
           //modulesViewModel.modules = modules;
            Func<Module, IComparable> func = null;
            func = (Module a) => a.ModuleId;

            var paginatedModules = new PaginatedList<Module>(modules, page ?? 0, func, pageSize);
            modulesViewModel.modules = paginatedModules;

            return View(modulesViewModel);
        }

        // GET: Modules/Details/5
        public ActionResult Details(int id=0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = repository.GetModule(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            var othermodules = repository.GetModuleLeaderModules(module.ModuleLeader);
            ModuleDetailsViewModel moduleDetailsViewModel = new ModuleDetailsViewModel();
            moduleDetailsViewModel.othermodules = othermodules;
            moduleDetailsViewModel.module = module;
            return View(moduleDetailsViewModel);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModuleId,ModuleTitle,ModuleLeader,ModuleDescription,ImageURL,Keyword,Category")] Module module)
        {
            if (ModelState.IsValid)
            {
                repository.AddModule(module);
                repository.Save();
                return RedirectToAction("Details", new { Id = module.ModuleId });
            }

            return View(module);
        }

        // GET: Modules/Edit/5
        public ActionResult Edit(int id=0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = repository.GetModule(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModuleId,ModuleTitle,ModuleLeader,ModuleDescription,ImageURL,Keyword,Category")] Module module)
        {
            if (ModelState.IsValid)
            {
                int moduleId = module.ModuleId;
                repository.UpdateModule(module);
                repository.Save();
                return RedirectToAction("Details", new { Id = moduleId });
            }
            return View(module);
        }

        // GET: Modules/Delete/5
        public ActionResult Delete(int id=0)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = repository.GetModule(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteModule(id);
            repository.Save();
            return RedirectToAction("Index");
        }

     

        //
        // GET: /Albums/Search/Blue
        
        public ActionResult Search(int? page, string search_string)
        {
            const int pageSize = 12;

            ModulesViewModel modulesViewModel = new ModulesViewModel();
            IQueryable<Category> categories = repository.GetCategories(search_string);
            modulesViewModel.categories = categories;
            IQueryable<Module> Modules = repository.Search(search_string);

            Func<Module, IComparable> func = null;
            func = (Module a) => a.ModuleId;

            var paginatedModules = new PaginatedList<Module>(Modules, page ?? 0, func, pageSize);
            modulesViewModel.modules = paginatedModules;
            ViewBag.search_string = search_string;
            return View(modulesViewModel);
        }
        
        //
        // POST: /Module/Search/Blue

        [HttpPost]
         public ActionResult Search(FormCollection formValues)
         {
             const int pageSize = 12;
             int page = 0;
             string search_string = Request.Form["searchText"];
             ViewBag.category = null;
             ModulesViewModel modulesViewModel = new ModulesViewModel();
             IQueryable<Category> categories = repository.GetCategories(search_string);
             modulesViewModel.categories = categories;
             IQueryable<Module> Modules = repository.Search(search_string);


             Func<Module, IComparable> func = null;
             func = (Module a) => a.ModuleId;

             var paginatedModules = new PaginatedList<Module>(Modules, page, func, pageSize);
             modulesViewModel.modules = paginatedModules;
             ViewBag.search_string = search_string;
             return View(modulesViewModel);
           }

        //
        // GET: /Module/Filter/1/Music/Blue/Rock

        public ActionResult Filter(int? page, string category = null, string search_string = null, string keyword = null)
        {
            // Some Hints:
            const int pageSize = 12;
            ModulesViewModel modulesViewModel = new ModulesViewModel();
            IQueryable<Module> modules = repository.Search(search_string);
            IQueryable<Category> categories = repository.GetCategories(search_string, keyword);
            modulesViewModel.categories = categories;

            modules = repository.Filter(category, search_string, keyword);
            Func<Module, IComparable> func = null;
            func = (Module a) => a.ModuleId;
            var paginatedModules = new PaginatedList<Module>(modules, page ?? 0, func, pageSize);
            modulesViewModel.modules = paginatedModules;

            ViewBag.search_string = search_string;
            ViewBag.category = category;
            ViewBag.keyword = keyword;
            return View(modulesViewModel);

            //return View("NotYetImplemented");
        }

        //
        // GET: /Module/ModuleLeaders

        public ActionResult ModuleLeaders()
        {
            IEnumerable<ModuleLeader> moduleLeaders = repository.GetModuleLeaders();
            return View(moduleLeaders);
        }


        //
        // GET: /Module/ModuleAdmin
        public ActionResult Admin()
        {
            Module module = new Module();
            IEnumerable<ModuleLeader> moduleleaders = repository.GetModuleLeaders();

            AdminViewModel adminViewModel = new AdminViewModel();
            adminViewModel.module = module;
            adminViewModel.moduleleaders = moduleleaders;

            ViewBag.action = "Create";

            return View(adminViewModel);

            
        }

        //[HttpPost]
        //[MultiButton(MatchFormKey = "action", MatchFormValue = "Select Module Leader")]
        //public ActionResult SelectModuleLeader(FormCollection formValues)
        //{
        //    string artist = Request.Form["moduleleaders"];
        //    Module module = new Module();

        //    IEnumerable<ModuleLeader> moduleleaders = repository.GetModuleLeaders();
        //    IEnumerable<Module> leadersmodules = repository.GetModuleLeaderModules(moduleleader);

        //    AdminViewModel adminViewModel = new AdminViewModel();

        //    adminViewModel.module = module;
        //    adminViewModel.moduleleaders = moduleleaders;
        //    adminViewModel.module = leadersmodules;

        //    ViewBag.action = "Create";

        //    return View("Admin", adminViewModel);
        //}


        // POST: /Albums/SelectModule/1

        [HttpPost]
        [MultiButton(MatchFormKey = "action", MatchFormValue = "Select Module")]
        public ActionResult SelectModule(FormCollection formValues)
        {
            int id = Convert.ToInt32(Request.Form["modules"]);

            Module module = repository.GetModule(id);

            IEnumerable<ModuleLeader> moduleleaders = repository.GetModuleLeaders();

            AdminViewModel adminViewModel = new AdminViewModel();

            adminViewModel.moduleleaders = moduleleaders;
            adminViewModel.module = module;

            ViewBag.action = "Edit";
            return View("Admin", adminViewModel);
        }


        //
        // GET: /Module/StudentAdmin

        public ActionResult StudentAdmin()
          {
              return View("NotYetImplemented");
          }

        public ActionResult AdvancedSearch()
        {
            return View("_a_searchbox");
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

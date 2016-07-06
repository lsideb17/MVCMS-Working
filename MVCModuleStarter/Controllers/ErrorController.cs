using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace MVCModuleStarter.Controllers
{
    public class ErrorController : Controller
    {
       // private ModulesRepository repository = new ModulesRepository(new ModuleContext());

        public ActionResult Error()
        {
            return View();
        }

       
    }
}
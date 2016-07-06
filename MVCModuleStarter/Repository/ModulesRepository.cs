using System;
using System.Linq;
using MVCModuleStarter.Models;

namespace MVCModuleStarter.Repository
{
    public class ModulesRepository:IModulesRepository
    {
        private ModuleContext context;

        public ModulesRepository(ModuleContext context)
        {
            this.context = context;
        }

       

        public IQueryable<Module> GetAllModules()
        {
            return context.Modules;
        }

        public IQueryable<Module> GetRecentModules()
        {
            IQueryable<Module> result =
                (from a in context.Modules
                 orderby a.ModuleId descending
                 select a).Take(12);
            return result;
        }

        public IQueryable<Module> GetRandomModules()
        {
            IQueryable<Module> result =
                (from a in context.Modules
                 orderby a.ModuleId descending
                 select a).OrderBy(x => Guid.NewGuid()).Take(12);
            return result;
        }

        public Module GetModule(int moduleId)
        {
            return context.Modules.Find(moduleId);
        }

        public IQueryable<Category> GetCategories(string search_string = null, string keyword = null)
        {
            IQueryable<Module> modules = context.Modules;
            if (search_string != null)
            {
                modules = (from m in modules
                           where (m.ModuleTitle.ToUpper().Contains(search_string) || m.ModuleLeader.ToUpper().Contains(search_string))
                           orderby m.ModuleId
                           select m).Distinct();
            }
            if (keyword != null)
            {
                modules = (from m in modules
                           where m.Keywords.Any(k => k.KeywordTerm == keyword)
                           orderby m.ModuleId
                           select m).Distinct();
            }
            IQueryable<Category> categories =
                  (from m in modules
                   group m by m.Category into categorygroup
                   select new Category() { category = categorygroup.Key, kount = categorygroup.Count() });
            return categories;            
        }

        public IQueryable<Module> GetModuleLeaderModules(string moduleLeader)
        {
            IQueryable<Module> Result =
              (from c in context.Modules
               where c.ModuleLeader.Contains(moduleLeader)
               orderby c.ModuleId
               select c);
            return Result;
        }

        public IQueryable<ModuleLeader> GetModuleLeaders()
        {
            IQueryable<ModuleLeader> Result =
              (from c in context.Modules
               group c by c.ModuleLeader into leadergroup
               select new ModuleLeader() { moduleleader = leadergroup.Key, kount = leadergroup.Count() });
            return Result;
        }

        public IQueryable<Keyword> GetAllKeywords()
        {
            return context.Keywords;
        }

        public Keyword GetKeyword(int id)
        {
            return context.Keywords.SingleOrDefault(d => d.KeywordId == id);
        }

        public IQueryable<Module> Search(string search_string)
        {
            IQueryable<Module> Result =
              (from c in context.Modules
               where (c.ModuleTitle.ToUpper().Contains(search_string) || c.ModuleLeader.ToUpper().Contains(search_string))
               orderby c.ModuleId
               select c).Distinct();
            return Result;
        }

        public IQueryable<Module> Filter(string cat= null, string search_string = null, string keyword = null)
         {
             IQueryable<Module> modules = context.Modules;
             if (search_string != null)
             {
                 modules = (from m in modules
                            where (m.ModuleTitle.ToUpper().Contains(search_string) || m.ModuleLeader.ToUpper().Contains(search_string))
                            orderby m.ModuleId
                            select m).Distinct();
             }
             if (cat != null)
             {
                 modules = (from m in modules
                            where m.Category == cat
                            orderby m.ModuleId
                            select m).Distinct();
             }
             if (keyword != null)
             {
                 modules = (from m in modules
                            where m.Keywords.Any(k => k.KeywordTerm == keyword)
                            orderby m.ModuleId
                            select m).Distinct();            
             }
             return modules;
         }

        //public IQueryable<Module> Filter(string cat, string search_string = null, string keyword = null)
        // {
        //     if (search_string != null)
        //     {
        //         string searchterm = search_string.ToString();
        //         IQueryable<Module> Result =
        //             (from c in context.Modules
        //              where c.Category == cat && (c.ModuleTitle.Contains(searchterm) || c.ModuleLeader.Contains(searchterm))
        //              orderby c.ModuleId
        //              select c).Distinct();
        //         return Result;
        //     }
        //     else
        //     {
        //         IQueryable<Module> Result =
        //           (from c in context.Modules
        //            where c.Category == cat
        //            orderby c.ModuleId
        //            select c).Distinct();
        //         return Result;
        //     }

        // }

 
        public void AddModule(Module module)
        {
            context.Modules.Add(module);
        }

        public void DeleteModule(int moduleId)
        {
            Module module = context.Modules.Find(moduleId);
            context.Modules.Remove(module);
        }

        public void UpdateModule(Module module)
        {
            context.Entry(module).State = System.Data.Entity.EntityState.Modified;
        }

        public void AddKeyword(Keyword keyword)
        {
            context.Keywords.Add(keyword);
        }

        public void UpdateKeyword(Keyword keyword)
        {
            context.Entry(keyword).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
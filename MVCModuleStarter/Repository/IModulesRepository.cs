
using System;
using System.Linq;
using MVCModuleStarter.Models;

namespace MVCModuleStarter.Repository
{
    interface IModulesRepository:IDisposable
    {
        IQueryable<Module> GetAllModules();
        IQueryable<Module> GetRecentModules();
        IQueryable<Module> GetRandomModules();
        IQueryable<Category> GetCategories(string search_string=null, string keyword=null);
        Module GetModule(int moduleId);
        IQueryable<Module> GetModuleLeaderModules(string moduleLeader);
        IQueryable<ModuleLeader> GetModuleLeaders();
        IQueryable<Keyword> GetAllKeywords();
        Keyword GetKeyword(int id);
        IQueryable<Module> Search(string search_string);
        IQueryable<Module> Filter(string cat = null, string search_string = null, string keyword = null);
        void AddModule(Module module);
        void DeleteModule(int moduleId);
        void UpdateModule(Module module);
        void AddKeyword(Keyword keyword);
        void UpdateKeyword(Keyword keyword);
        void Save();
    }
}

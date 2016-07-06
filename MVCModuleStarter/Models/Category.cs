using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCModuleStarter.Models
{
    public class Category
    {
        public string category { get; set; }
        public int kount { get; set; }

        public Category(string p_1, int p_2)
        {            
            this.category = p_1;
            this.kount = p_2;
        }

        public Category() { }
    }

}
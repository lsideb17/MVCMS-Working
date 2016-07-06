using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCModuleStarter.Models
{
    public class ModuleLeader
    {
        public string moduleleader { get; set; }
        public int kount { get; set; }

        public ModuleLeader(string p_1, int p_2)
        {
            this.moduleleader = p_1;
            this.kount = p_2;
        }

        public ModuleLeader() { }
    }
}
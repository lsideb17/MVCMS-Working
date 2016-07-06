using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCModuleStarter.Models
{
    public class Keyword
    {
        /*[Column(Order = 0), Key, Display(Name = "Module")]
         public int ModuleId { get; set; }*/

        [Column(Order = 1), Key, Display(Name = "ID")]
        public int KeywordId { get; set; }

        [Required, StringLength(100), Display(Name = "Keyword")]
        public string KeywordTerm { get; set; }

        public virtual ICollection<Module> Modules { get; set; }
    }
}
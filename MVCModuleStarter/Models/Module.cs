using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCModuleStarter.Models
{
    public class Module
    {
        [Key, Display(Name = "ID")]
        public int ModuleId { get; set; }

        [Required, StringLength(100), Display(Name = "Title")]
        public string ModuleTitle { get; set; }

        [Required, StringLength(50), Display(Name = "Leader")]
        public string ModuleLeader { get; set; }

        [Required, StringLength(1000), Display(Name = "Description")]
        public string ModuleDescription { get; set; }

        [StringLength(150), Display(Name = "Image")]
        public string ImageURL { get; set; }

        //[StringLength(50), Display(Name = "Keyword")]
        //public string Keyword { get; set; }

        [Required, StringLength(20), Display(Name = "Category")]
        public string Category { get; set; }


        public virtual ICollection<Keyword> Keywords { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
  
}
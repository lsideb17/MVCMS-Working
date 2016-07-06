using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCModuleStarter.Models
{
    public class Student
    {
        [Key, Display(Name = "ID")]
        public int StudentId { get; set; }

        [Required, StringLength(100), Display(Name = "Title")]
        public string StudentTitle { get; set; }

        [Required, StringLength(50), Display(Name = "Name")]
        public string StudentName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "DOB")]
        public DateTime StudentDOB { get; set; }

        [StringLength(150), Display(Name = "Image")]
        public string ImageURL { get; set; }

        public virtual ICollection<Module> Modules { get; set; }
    }
}
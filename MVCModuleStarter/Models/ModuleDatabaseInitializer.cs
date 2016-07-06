using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;

namespace MVCModuleStarter.Models
{
    public class ModuleDatabaseInitializer : DropCreateDatabaseAlways<ModuleContext>
  {
        public ModuleDatabaseInitializer()
        {
            ModuleContext context = new ModuleContext();
            this.InitializeDatabase(context);
        }

      protected override void Seed(ModuleContext context)
    {
        GetModules().ForEach(m => context.Modules.Add(m));
        GetKeywords().ForEach(k => context.Keywords.Add(k));
        GetStudents().ForEach(s => context.Students.Add(s));
    }

      private static List<Module> GetModules()
    {
        var modules = new List<Module> {
                new Module
                {
                    ModuleId = 1,
                    ModuleTitle = "Ryan Jarman - Modern Guitar Heroes",
                    ModuleLeader = "Ajhod Singh",
                    ModuleDescription = "Ryan Jarman is a guitarist in the indie rock band 'The Cribs'. He is born and resides from Wakefield along with his brothers who are also in the band, Ross (drummer) is his younger brother and Gary (bassist) is his twin brother. In 2013 'The Cribs' were awarded the Outstanding Contribution To Music award by the NME and The Spirit Of Independence award by Q magazine. Ryan has suffered from a few health issues in the past, he has accidently cut himself in 2007 at the NME award which required internal stiches and has also suffered from physiological problem which caused him to lose weight. He also been in NME cool list in 2006 and 2007.",
                    ImageURL = "as_ryanjarman.jpg",
                    Category = "Music"
                },
                new Module
                {
                    ModuleId = 2,
                    ModuleTitle = "Kalpen Suresh Modi (Kal penn) - Not Your Typical Hollwood Star",
                    ModuleLeader = "Ajhod Singh",
                    ModuleDescription = "Kal penn is an Asian American actor that has starred in a variety of movies and sitcoms including the 'Harold & Kumar' and 'How I met your mother'. He was born and grew up in Montclair, New Jersey USA although his mother and father were originally Gujarati immigrants from India. Kal penn has strong political interests and was part of president Obama presidency campaign. In 2009 he was appointed associate director of the 'White House Office of Public Engagement' which involved him reaching out and liaising with the Asian American, Pacific Islander and arts communities.",
                    ImageURL = "as_kalpenn.jpg",
                    Category = "Actor"
                },
                new Module
                {
                    ModuleId = 3,
                    ModuleTitle = "Sachin Tendulkar (cricketer) - The Little Master",
                    ModuleLeader = "Ajhod Singh",
                    ModuleDescription = "Sachin Tendulkar is a former Indian cricketer born in Bombay who made his international ODI debut aged 16 for India.  He his incredibly talented batsmen and has made over 34,000 runs in all forms of international cricket and is the only player to do so yet. He is also scored the most runs in Test cricket. He also holds the record for most centuries in ODI and Test cricket. In 2013 his estimated net worth was 160 million USD according to wealth x. In April 2012, Tendulkar accepted the 'Rajya Sabha' (upper house of the parliament of India) nomination proposed by the President of India and became the first active sportsperson and cricketer to have been nominated.",
                    ImageURL = "as_sachintendulkar.jpg",
                    Category = "Sports"
                },
      };

      return modules;
    }

      private static List<Keyword> GetKeywords()
    {
        var keywords = new List<Keyword> {
                new Keyword { 
                      KeywordId = 1,
                      KeywordTerm = "007"
                  },
                new Keyword { 
                      KeywordId = 2,
                      KeywordTerm = "1950s"
                  },
                new Keyword { 
                      KeywordId = 3,
                      KeywordTerm = "1960s"
                  },
                new Keyword { 
                      KeywordId = 4,
                      KeywordTerm = "3D Modelling"
                  },
                new Keyword { 
                      KeywordId = 5,
                      KeywordTerm = "50s"
                  },
                new Keyword { 
                      KeywordId = 6,
                      KeywordTerm = "50s Films"
                  },
                new Keyword { 
                      KeywordId = 7,
                      KeywordTerm = "60s"
                  },
                new Keyword { 
                      KeywordId = 8,
                      KeywordTerm = "ABC"
                  },
                new Keyword { 
                      KeywordId = 9,
                      KeywordTerm = "Academic"
                  },
                new Keyword { 
                      KeywordId = 10,
                      KeywordTerm = "Acoustic"
                  }
            };

      return keywords;
    }

      private static List<Student> GetStudents()
      {
          var students = new List<Student> {
                new Student
                {
                    StudentId = 1,
                    StudentTitle = "Mr",
                    StudentName = "Xavi Hernandez",
                    StudentDOB = new DateTime(1976, 11, 10),
                    ImageURL = "xavihernandez.jpg",
                },
                new Student
                {
                    StudentId = 1,
                    StudentTitle = "Mrs",
                    StudentName = "Carly Simon",
                    StudentDOB = new DateTime(1956, 03, 17),
                    ImageURL = "carlysimon.jpg",
                }
      };

          return students;
      }

  }
}
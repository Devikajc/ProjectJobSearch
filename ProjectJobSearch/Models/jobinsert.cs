using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectJobSearch.Models
{
   
    public class JSkillCheckBoxListHelper
    {
        public string jsvalue { get; set; }
        public string jstext { get; set; }
        public bool jsischecked { get; set; }
    }
    public class jobinsert
    {
        public List<JSkillCheckBoxListHelper> MyJSkills { get; set; }
        public string[] selectedjskill { get; set; }
       
        public int company_id { get; set; }
        public string job_title { get; set; }
        public string job_experience { get; set; }
        public string job_skills { get; set; }
        public int job_vacancy { get; set; }
        [Display(Name ="Last Date")]
        [DataType(DataType.Date)]
        public DateTime ? job_date { get; set; }
        public string job_status { get; set; }
        public string jobmsg { get; set; }
    }
}
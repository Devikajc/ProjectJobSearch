using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectJobSearch.Models
{
    public class applycls
    {
       
        public int user_id { get; set; }
        public int job_id { get; set; }
        public string app_resume { get; set; }
        
        public DateTime? apply_date { get; set; }
       
        public string applymsg { get; set; }
    }
}
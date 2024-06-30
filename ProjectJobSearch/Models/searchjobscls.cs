using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectJobSearch.Models
{
    public class searchjobscls
    {
        public searchjobscls()
            {
            selectjob = new List<jsearch>();
            insertse = new jsearch();

            }
        public jsearch insertse { set; get; }
        public List<jsearch> selectjob { set; get; }

        internal object sp_jobsearch(string qry)
        {
            throw new NotImplementedException();
        }
    }

    public class jsearch
    {
        public int job_id { get; set; }
        public int company_id { get; set; }
        public string job_title { get; set; }
        public string job_experience { get; set; }
        public string job_skills { get; set; }
        public int job_vacancy { get; set; }
        [Display(Name = "Last Date")]
        [DataType(DataType.Date)]
        public DateTime? job_date { get; set; }
        public string job_status { get; set; }
        //public string jobmsg { get; set; }
    }
}
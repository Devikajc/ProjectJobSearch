using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectJobSearch.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Ajax.Utilities;

namespace ProjectJobSearch.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        SqlConnection con = new SqlConnection(@"server=DESKTOP-DH6TSIN\SQLEXPRESS;database=JobSearchProjectDB;Integrated security=true");
        JobSearchProjectDBEntities dbobj = new JobSearchProjectDBEntities();
        
        public ActionResult search_pageload()
        {
            return View(GetData());
        }
        

            public ActionResult search_click(searchjobscls clsobj)
            {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.job_title))
            {
                qry += " and job_title like '%" + clsobj.insertse.job_title + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.job_experience))
            {
                qry += " and job_experience like '%" + clsobj.insertse.job_experience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.job_skills))
            {
                qry += " and job_skills like '%" + clsobj.insertse.job_skills + "%'";
            }
            return View("search_pageload", getdata1(clsobj, qry));
        }
        public searchjobscls getdata1(searchjobscls clsobj, string qry)
        {
            SqlCommand cmd = new SqlCommand("sp_jobsearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@qry", qry);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            var joblist = new searchjobscls();
            while (dr.Read())
            {
                var jobcls = new jsearch();
                jobcls.company_id = Convert.ToInt32(dr["company_id"].ToString());
                jobcls.job_title = dr["job_title"].ToString();
                jobcls.job_experience = dr["job_experience"].ToString(); ;
                jobcls.job_skills = dr["job_skills"].ToString();
                jobcls.job_vacancy = Convert.ToInt32(dr["job_vacancy"].ToString());
                jobcls.job_date = Convert.ToDateTime(dr["job_date"].ToString());
                jobcls.job_status = dr["job_status"].ToString();


                joblist.selectjob.Add(jobcls);
            }
            con.Close();
            return joblist;

        }
      
        private searchjobscls GetData()
        {
            var joblist = new searchjobscls();
            List<string> lst = new List<string>();
            var job = dbobj.jobstables.ToList();
            foreach (var e in job)
            {
                var jobcls = new jsearch();
                jobcls.job_id = e.job_id;
                jobcls.company_id = e.company_id;
                jobcls.job_title = e.job_title;
                jobcls.job_experience = e.job_experience;
                jobcls.job_skills = e.job_skills;
                jobcls.job_vacancy = e.job_vacancy;
                jobcls.job_date = e.job_date;
                jobcls.job_status = e.job_status;
                

                joblist.selectjob.Add(jobcls);

                var s = jobcls.job_skills;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
            }
            return joblist;
        }


    }
}
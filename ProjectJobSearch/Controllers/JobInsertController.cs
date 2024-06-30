using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectJobSearch.Models;

namespace ProjectJobSearch.Controllers
{
    public class JobInsertController : Controller
    {
        JobSearchProjectDBEntities obj = new JobSearchProjectDBEntities();
        // GET: JobInsert
        public ActionResult jobinsert_pageload()
        {
            jobinsert j = new jobinsert();
            j.MyJSkills = getJSkillsData();
            return View(j);
            
            
        }
        public List<JSkillCheckBoxListHelper> getJSkillsData()
        {
            List<JSkillCheckBoxListHelper> sts2 = new List<JSkillCheckBoxListHelper>
            {
                new JSkillCheckBoxListHelper{ jsvalue="ASP .NET",jstext="ASP .NET",jsischecked=false},
                new JSkillCheckBoxListHelper{ jsvalue="MVC",jstext="MVC",jsischecked=false},
                new JSkillCheckBoxListHelper{ jsvalue="MVC CORE",jstext="MVC CORE",jsischecked=false},
                new JSkillCheckBoxListHelper{ jsvalue="WEB API",jstext="WEB API",jsischecked=false},
                new JSkillCheckBoxListHelper{ jsvalue="ANGULAR",jstext="ANGULAR",jsischecked=false},
                 new JSkillCheckBoxListHelper{ jsvalue="PYTHON",jstext="PYTHON",jsischecked=false},
                new JSkillCheckBoxListHelper{ jsvalue="C#",jstext="C#",jsischecked=false},
                new JSkillCheckBoxListHelper{ jsvalue="HTML",jstext="HTML",jsischecked=false},
                new JSkillCheckBoxListHelper{ jsvalue="WEB DESIGN",jstext="WEB DESIGN",jsischecked=false},
                new JSkillCheckBoxListHelper{ jsvalue="JAVASCRIPT",jstext="JAVASCRIPT",jsischecked=false}

            };

            return sts2;

        }
        public ActionResult jobinsert_click(jobinsert clsobj, FormCollection form)
        {
           
            if (ModelState.IsValid)
            {
               

                var sk = string.Join(",", clsobj.selectedjskill);
                clsobj.job_skills = sk;
                clsobj.MyJSkills = getJSkillsData();
                obj.sp_jobs(Convert.ToInt32(Session["uid"]), clsobj.job_title, clsobj.job_experience, clsobj.job_skills, clsobj.job_vacancy, clsobj.job_date, "available");
                clsobj.jobmsg = "Successfully Added Job";
                return View("jobinsert_pageload", clsobj);
                
            }

            else {
               
                clsobj.MyJSkills = getJSkillsData();
            }

            return View("jobinsert_pageload", clsobj);
        }
    }
}
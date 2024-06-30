using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectJobSearch.Models;

namespace ProjectJobSearch.Controllers
{
    public class UserRegController : Controller
    {
        // GET: UserReg
        JobSearchProjectDBEntities obj = new JobSearchProjectDBEntities();
        public ActionResult userreg_pageload()
        {
           
            UserInsert user1 = new UserInsert();
            
            user1.MyFavouriteQual = getQualificationData();
            user1.MySkills = getSkillsData();
            return View(user1);

            
        }
        public List<CheckBoxListHelper> getQualificationData()
        {
            List<CheckBoxListHelper> sts1 = new List<CheckBoxListHelper>
            {
                new CheckBoxListHelper{ value="SSLC",text="SSLC",ischecked=true},
                new CheckBoxListHelper{ value="PLUS TWO",text="PLUS TWO",ischecked=false},
                new CheckBoxListHelper{ value="BCA",text="BCA",ischecked=false},
                new CheckBoxListHelper{ value="MCA",text="MCA",ischecked=false},
                new CheckBoxListHelper{ value="BTECH",text="BTECH",ischecked=false}

            };

            return sts1;

        }
        public List<SkillCheckBoxListHelper> getSkillsData()
        {
            List<SkillCheckBoxListHelper> sts2 = new List<SkillCheckBoxListHelper>
            {
                new SkillCheckBoxListHelper{ svalue="ASP .NET",stext="ASP .NET",sischecked=false},
                new SkillCheckBoxListHelper{ svalue="MVC",stext="MVC",sischecked=false},
                new SkillCheckBoxListHelper{ svalue="MVC CORE",stext="MVC CORE",sischecked=false},
                new SkillCheckBoxListHelper{ svalue="WEB API",stext="WEB API",sischecked=false},
                new SkillCheckBoxListHelper{ svalue="ANGULAR",stext="ANGULAR",sischecked=false},
                new SkillCheckBoxListHelper{ svalue="PYTHON",stext="PYTHON",sischecked=false},
                new SkillCheckBoxListHelper{ svalue="C#",stext="C#",sischecked=false},
                new SkillCheckBoxListHelper{ svalue="HTML",stext="HTML",sischecked=false},
                new SkillCheckBoxListHelper{ svalue="WEB DESIGN",stext="WEB DESIGN",sischecked=false},
                new SkillCheckBoxListHelper{ svalue="JAVASCRIPT",stext="JAVASCRIPT",sischecked=false}

            };

            return sts2;

        }
        public ActionResult userreg_click(UserInsert clsobj, HttpPostedFileBase file, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/phs");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    //for table of db save
                    var fullpath = Path.Combine("~\\phs", fname);
                    clsobj.user_resume = fullpath;
                }

           
                var getmaxid = obj.sp_MaxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                var quid1 = string.Join(",", clsobj.selectedqual);
                clsobj.user_qualification = quid1;
                clsobj.MyFavouriteQual = getQualificationData();
                var quid2 = string.Join(",", clsobj.selectedskill);
                clsobj.user_skills = quid2;
                clsobj.MySkills = getSkillsData();
                obj.sp_userreg(regid, clsobj.user_name, clsobj.user_age, clsobj.user_address, clsobj.user_phone, clsobj.user_email, clsobj.user_qualification, clsobj.user_skills, clsobj.user_experience, clsobj.user_resume);
                obj.sp_logininsert(regid, clsobj.username, clsobj.password, "user");

                clsobj.usermsg = "Successfully Registered as User";
                return View("userreg_pageload", clsobj);
                
            }
            else
            {
            
                clsobj.MyFavouriteQual = getQualificationData();
                clsobj.MySkills = getSkillsData();
            }

            return View("userreg_pageload", clsobj);
        }
    }
}
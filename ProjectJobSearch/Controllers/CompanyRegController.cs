using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectJobSearch.Models;

namespace ProjectJobSearch.Controllers
{
    public class CompanyRegController : Controller
    {
        // GET: CompanyReg
        JobSearchProjectDBEntities obj = new JobSearchProjectDBEntities();
        public ActionResult companyreg_pageload()
        {
            return View();
        }
        public ActionResult companyreg_click(CompanyInsert clsobj)
        {
            if (ModelState.IsValid)
            {
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
                obj.sp_companyreg(regid, clsobj.company_name, clsobj.company_address, clsobj.company_phone, clsobj.company_email,clsobj.company_website,clsobj.company_location);
                obj.sp_logininsert(regid, clsobj.username, clsobj.password, "company");

                clsobj.companymsg = "Successfully Registered as Admin";
                return View("companyreg_pageload", clsobj);
            }


            return View("companyreg_pageload", clsobj);
            //return View();
        }
    }
}
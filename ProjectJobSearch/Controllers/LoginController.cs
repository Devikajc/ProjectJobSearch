using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectJobSearch.Models;

namespace ProjectJobSearch.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        JobSearchProjectDBEntities obj = new JobSearchProjectDBEntities();
        public ActionResult login_pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult CompanyHome()
        {
            return View();
        }

        public ActionResult login_click(logincls objcls)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                obj.sp_logincount(objcls.username, objcls.password, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = obj.sp_loginid(objcls.username, objcls.password).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = obj.sp_logintype(objcls.username, objcls.password).FirstOrDefault();
                    if (lt == "user")
                    {
                       
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "company")
                    {
                        return RedirectToAction("CompanyHome");
                    }

                }

                else
                {
                    ModelState.Clear();
                    objcls.msg = "Invalid login";
                    return View("login_pageload", objcls);
                }
            }
            return View("login_pageload", objcls);
        }
    }
}
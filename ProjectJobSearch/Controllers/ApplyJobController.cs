using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectJobSearch.Models;

namespace ProjectJobSearch.Controllers
{
    public class ApplyJobController : Controller
    {
        // GET: ApplyJob
        JobSearchProjectDBEntities obj = new JobSearchProjectDBEntities();
        public ActionResult ApplyJob_pageload(int cid,int jid)
        {
            TempData["cid"] = cid;
            TempData["jid"] = jid;
            return View();
        }
        public ActionResult ApplyJob_click(applycls clsobj, HttpPostedFileBase file)
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
                    clsobj.app_resume = fullpath;
                }
                string dt = DateTime.Now.ToShortDateString();
                clsobj.apply_date = Convert.ToDateTime(dt);

                obj.sp_applicatoninsert(Convert.ToInt32(Session["uid"]),Convert.ToInt32(TempData["cid"]),Convert.ToInt32(TempData["jid"]),clsobj.app_resume,clsobj.apply_date,"applied");
                clsobj.applymsg = "Job Applied Succesful!!";
                return View("ApplyJob_pageload",clsobj);

            }
                return View("ApplyJob_pageload", clsobj);
        }
    }
}
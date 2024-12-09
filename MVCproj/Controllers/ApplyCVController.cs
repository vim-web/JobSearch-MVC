using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCproj.Models;

namespace MVCproj.Controllers
{
    public class ApplyCVController : Controller
    {
        MVCproEntities dbobj = new MVCproEntities();
        
        // GET: ApplyCV
        public ActionResult cv_pageload()
        {
            return View();
        }
        public ActionResult apply_click(CVApply clsobj, HttpPostedFileBase file, FormCollection form)
        {
            var jobid = Session["jid"];
            int job_id = Convert.ToInt32(jobid);
            var user = Session["uid"];
            int user_id = Convert.ToInt32(user);
            if (file.ContentLength > 0)
            {
                string fname = Path.GetFileName(file.FileName);
                var s = Server.MapPath("~/rsme");
                string pa = Path.Combine(s, fname);
                file.SaveAs(pa);

                var fullpath = Path.Combine("//rsme", fname);
                clsobj.resume = fullpath;
            }
            DateTime date = clsobj.appdate;
            dbobj.sp_resumeApply(user_id, job_id, clsobj.resume, "Applied", date);
            clsobj.apmsg = "Applied!!";
            return View("cv_pageload", clsobj);
        }
    }
}


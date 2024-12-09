using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCproj.Models;

namespace MVCproj.Controllers
{
    public class JobInsController : Controller
    {
        MVCproEntities dbobj = new MVCproEntities();
        // GET: JobIns
        public ActionResult Insert_Pageload()
        {
            return View();
        }
        public ActionResult InsertJob_ck(JobInsert clsobj)
        {
            var comid = Session["uid"];
            var uid = Convert.ToInt32(comid);

            DateTime closingtime = clsobj.closingdate;

            dbobj.sp_jobInsert(clsobj.JobTitle, clsobj.JobDes, clsobj.JobSkls, uid, closingtime, "open");
            clsobj.Cmsg = "posted Successfully";
            return View("Insert_Pageload", clsobj);
        }
    }
}
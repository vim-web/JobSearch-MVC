using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCproj.Models;

namespace MVCproj.Controllers
{
    public class ViewJobController : Controller
    {
        MVCproEntities dbobj = new MVCproEntities();
        // GET: ViewJob
        public ActionResult JobView_Pageload()
        {
            string qry = "";
            var data = dbobj.sp_jv(qry).ToList();
            ViewBag.openings = data;
            return View();
        }
    }
}
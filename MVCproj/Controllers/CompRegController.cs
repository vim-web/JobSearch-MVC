using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCproj.Models;

namespace MVCproj.Controllers
{
    public class CompRegController : Controller
    {
        MVCproEntities dboj = new MVCproEntities();
        // GET: CompReg
        public ActionResult insert_comp()
        {
            return View();
        }
        public ActionResult Comp_Insertclick(CompInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxId = dboj.sp_maxid().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxId);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }

                dboj.sp_CompanyInsert(regid, clsobj.Cname, clsobj.email, clsobj.phone, clsobj.address, clsobj.website);
                dboj.sp_login(regid, clsobj.username, clsobj.pass, "admin");
                clsobj.adminmsg = "Successfully Inserted";
                return View("insert_comp", clsobj);
            }
            return View("insert_comp", clsobj);
        }
    }
}
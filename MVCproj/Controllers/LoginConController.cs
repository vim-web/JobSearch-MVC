using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCproj.Models;

namespace MVCproj.Controllers
{
    public class LoginConController : Controller
    {
        MVCproEntities dbobj = new MVCproEntities();
        // GET: LoginCon
        public ActionResult Login_Pageload()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Login_Click(Loginn objcls)
        {
            if (ModelState.IsValid)
            {
                var val = dbobj.sp_loginCount(objcls.uname, objcls.password).Single();

                if (val == 1)
                {
                    var uid = dbobj.sp_loginId(objcls.uname, objcls.password).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = dbobj.sp_loginType(objcls.uname, objcls.password).FirstOrDefault();

                    if (lt == "user")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (lt == "admin")
                    {
                        return RedirectToAction("AdminHome");
                    }

                }
            }
            else
            {
                ModelState.Clear();
                objcls.msg = "invalid login";
                return View("Login_pageload", objcls);
            }
            return View("Login_pageload", objcls);
        }
    }
}
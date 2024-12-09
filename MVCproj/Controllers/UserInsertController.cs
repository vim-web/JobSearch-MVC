using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCproj.Models;

namespace MVCproj.Controllers
{
    public class UserInsertController : Controller
    {
        MVCproEntities dbobj = new MVCproEntities();

        // GET: UserInsert
        public ActionResult User_insertPageload()
        {
            UserReg user = new UserReg();
            user.MyFavoriteQual = getQualificationData();
            return View(user);
        }
        public List<checkBoxListHelper> getQualificationData()
        {
            List<checkBoxListHelper> sts = new List<checkBoxListHelper>()
            {
                new checkBoxListHelper {value="sslc",txt="sslc",ischecked=true},
                new checkBoxListHelper {value="plus two",txt="plus two",ischecked=false},
                new checkBoxListHelper {value="bca",txt="bca",ischecked=false},
                 new checkBoxListHelper {value="bsc",txt="bsc",ischecked=false},
                  new checkBoxListHelper {value="msc",txt="msc",ischecked=false},
                new checkBoxListHelper {value="mca",txt="mca",ischecked=false}
            };
            return (sts);
        }


        public ActionResult User_insClick(UserReg clsobj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/photo");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\photo", fname);
                    clsobj.photo = fullpath;//set
                }
                var getmaxid = dbobj.sp_maxid().FirstOrDefault();
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
                var quid = string.Join(",", clsobj.selectedQual);
                clsobj.Qualification = quid;//set
                clsobj.MyFavoriteQual = getQualificationData();



                dbobj.sp_userinsert(regid, clsobj.name, clsobj.age, clsobj.address, clsobj.email, clsobj.photo, clsobj.phone, clsobj.Skills, clsobj.exp, clsobj.Location, clsobj.Qualification);
                dbobj.sp_login(regid, clsobj.username, clsobj.pass, "user");
                clsobj.usermsg = "Successfully Inserted";
                return View("User_insertPageload", clsobj);


            }
            else
            {
                clsobj.MyFavoriteQual = getQualificationData();
            }
            return View("User_insertPageload", clsobj);
        }
    }
}
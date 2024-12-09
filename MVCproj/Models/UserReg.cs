using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCproj.Models
{
    public class checkBoxListHelper
    {
        public string value { set; get; }
        public string txt { set; get; }
        public bool ischecked { set; get; }
    }
    public class UserReg
    {
        public List<checkBoxListHelper> MyFavoriteQual { get; set; }
        public string[] selectedQual { get; set; }
        public int uid { set; get; }

        [Required(ErrorMessage = "Enter the Name")]
        public string name { set; get; }

        [Range(18, 50, ErrorMessage = "enter the Age")]
        public int age { get; set; }

        [Required(ErrorMessage = "Enter the address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Enter the Valid email Id")]
        public string email { get; set; }

        public string photo { get; set; }

        [Required(ErrorMessage = "Enter the Phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Valid number")]
        public string phone { set; get; }

        public string Skills { get; set; }

        public string exp { get; set; }

        public string Location { get; set; }

        public string Qualification { get; set; }


        [Required(ErrorMessage = "Enter the UserName")]
        public string username { get; set; }

        public string pass { set; get; }

        [Compare("pass", ErrorMessage = "Password Mismatch")]
        public string cpassword { set; get; }

        public string usermsg { get; set; }
    }
}
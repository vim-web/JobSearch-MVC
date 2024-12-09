using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCproj.Models
{
    public class CompInsert
    {
        [Required(ErrorMessage = "Enter the Name")]
        public string Cname { set; get; }

        [Required(ErrorMessage = "Enter the Valid email Id")]
        public string email { set; get; }

        [Required(ErrorMessage = "Enter the Phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter Valid number")]
        public string phone { set; get; }

        [Required(ErrorMessage = "Enter the address")]
        public string address { set; get; }

        [Required(ErrorMessage = "Enter the website")]
        public string website { set; get; }

        [Required(ErrorMessage = "Enter the UserName")]
        public string username { set; get; }
        public string pass { set; get; }

        [Compare("pass", ErrorMessage = "Password Mismatch")]
        public string cpassword { set; get; }

        public string adminmsg { set; get; }
    }
}
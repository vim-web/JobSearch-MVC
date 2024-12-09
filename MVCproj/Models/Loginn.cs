using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCproj.Models
{
    public class Loginn
    {
        [Required(ErrorMessage = "enter the username")]
        public string uname { set; get; }
        [Required(ErrorMessage = "enter the password")]
        public string password { set; get; }
        public string msg { set; get; }
        public string ltype { set; get; }
    }
}
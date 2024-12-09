using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCproj.Models
{
    public class JobInsert
    {
        [Required(ErrorMessage = "Enter the Job Title")]
        public string JobTitle { set; get; }

        [Required(ErrorMessage = "Enter the description")]
        public string JobDes { get; set; }

        [Required(ErrorMessage = "Enter the Valid jobskills")]
        public string JobSkls { get; set; }


        public DateTime closingdate { set; get; }

        public string Cmsg { set; get; }

    }
}
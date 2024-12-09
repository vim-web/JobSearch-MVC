using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCproj.Models
{
    public class CVApply
    {
        public int uid { set; get; }
        public int jid { set; get; }
        public string resume { set; get; }
        public string status { set; get; }
        public DateTime appdate { set; get; }

        public string apmsg { set; get; }
        

    }
}
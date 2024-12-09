using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCproj.Models
{
    public class JobSearch
    {
        public JobSearch()
        {
            selectjob = new List<jsearch>();
            insertse = new jsearch();

        }
        public jsearch insertse { set; get; }
        public List<jsearch> selectjob { set; get; }
    }
    public class jsearch
    {
        public int job_id { set; get; }
        public int compid { set; get; }
        public int u_id { set; get; }
        public string skills { set; get; }
        public string jobdes { set; get; }
        public string jstatus { set; get; }
        public string cdate { set; get; }
        public string jmsg { set; get; }



    }
}
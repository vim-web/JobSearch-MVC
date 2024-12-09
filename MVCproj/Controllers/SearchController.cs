using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCproj.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MVCproj.Controllers
{
    public class SearchController : Controller
    {
        MVCproEntities dbobj = new MVCproEntities();
        // GET: Search
        public ActionResult Search_index()
        {
            return View(GetData());
        }
        private JobSearch GetData()
        {
            var joblist = new JobSearch();
            List<string> lst = new List<string>();
            var job = dbobj.jobs.ToList();
            foreach (var e in job)
            {
                var jobcls = new jsearch();
                DateTime date = e.closing_date;
                jobcls.job_id = e.job_id;
                jobcls.compid = e.comp_id;
                jobcls.skills = e.jb_skills;
                jobcls.jobdes = e.jb_des;
                jobcls.jstatus = e.status;
                jobcls.cdate = date.ToString();
                joblist.selectjob.Add(jobcls);
                var s = jobcls.skills;
                lst.Add(s);
                TempData["ski"] = string.Join(" ", lst);
                Session["jid"] = jobcls.job_id;
            }

            return joblist;
        }
        public ActionResult search_click(JobSearch clsobj)
        {
            string qry = " ";
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.jobdes))
            {
                qry += " and jb_des like '%" + clsobj.insertse.jobdes + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.skills))
            {
                qry += " and jb_skills like '%" + clsobj.insertse.skills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(clsobj.insertse.jstatus))
            {
                qry += " and status like '%" + clsobj.insertse.jstatus + "%'";
            }
            return View("Search_index", getdata(clsobj, qry));
        }

        private JobSearch getdata(JobSearch clsobj, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["con1"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jv", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var joblist = new JobSearch();
                while (dr.Read())
                {
                    var jobcls = new jsearch();
                    jobcls.compid = Convert.ToInt32(dr["comp_id"].ToString());
                    jobcls.skills = dr["jb_skills"].ToString();
                    jobcls.jobdes = dr["jb_des"].ToString();
                    jobcls.jstatus = dr["status"].ToString();
                    jobcls.cdate = dr["closing_date"].ToString();
                    joblist.selectjob.Add(jobcls);
                }
                con.Close();
                return joblist;
            }
        }

    }
}
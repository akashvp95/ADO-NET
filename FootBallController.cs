using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootBallProject.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;

namespace FootBallProject.Controllers
{
    public class FootBallController : Controller
    { 
        FootBallContext db = new FootBallContext();
        //public ActionResult details(int id)
        //{
        //    Football football = db.FootballTable.Single(match => match.MatchID == id);
        //    return View(football);
        //}
        public ActionResult Index()
        {
            List<Football> football = db.FootballTable.ToList();
            return View(football);
        }

        [HttpPost]
        public void Save(string teamname1, string teamname2, string status, string winteam,int points)
        {
            SqlConnection con = new SqlConnection("data source = LMI-5F5G2G2\\SQLEXPRESS; database = ado_assignment; integrated security=SSPI");
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Execute spFootball @TeamName1,@TeamName2,@Status,@WinningTeam,@Points";
                cmd.Parameters.Add("@TeamName1", SqlDbType.VarChar, 50).Value = teamname1;
                cmd.Parameters.Add("@TeamName2", SqlDbType.VarChar, 50).Value = teamname2;
                cmd.Parameters.Add("@Status", SqlDbType.VarChar, 50).Value = status;
                cmd.Parameters.Add("@WinningTeam", SqlDbType.VarChar, 50).Value = winteam;
                cmd.Parameters.Add("@Points",SqlDbType.Int,4).Value = points;
                //adding paramerters to  SqlCommand below 
                
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
        }
    }
}
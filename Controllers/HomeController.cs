using Microsoft.AspNetCore.Mvc;
using SurveyTask.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SurveyTask.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int clickcount)
        {
            SqlConnection conn = new SqlConnection("Data Source=TMOOLA-L-5539\\SQLEXPRESS;Initial Catalog=Day1;User ID=sa;Password=Welcome2evoke@1234");

            if (clickcount==0)
            {
                int id = 1;
                      conn.Open();
                SqlCommand cmd = new SqlCommand("update SurveyProgress set StatusId=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                
            }
            if (clickcount == 1)
            {
                int id = 2;
                conn.Open();
                SqlCommand cmd = new SqlCommand("update SurveyProgress set StatusId=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }          
            if (clickcount == 2)
            {
                int id = 3;
                conn.Open();
                SqlCommand cmd = new SqlCommand("update SurveyProgress set StatusId=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();


            }
            conn.Close();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
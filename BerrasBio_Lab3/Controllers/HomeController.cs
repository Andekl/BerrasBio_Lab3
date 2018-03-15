using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BerrasBio_Lab3.Models;
using System.Data.SqlClient;
using System.Data;

namespace BerrasBio_Lab3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
        DataTable dt = new DataTable();
        string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BerrasBio;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(connection_string))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Filmer", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
                return View(dt);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

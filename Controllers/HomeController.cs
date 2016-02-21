using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ClassMate.DBO;
namespace ClassMate.Controllers
{
    public class HomeController : Controller
    {
        DBOHandler dboHandler = new DBOHandler(); 
        public IActionResult Index()
        {
            
           // ViewData["QueryData"]=handler.Query()[1].Name;
            return View(dboHandler.Query());
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
            return View();
        }
    }
}

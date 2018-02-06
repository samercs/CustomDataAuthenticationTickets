using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CustomDataAuthenticationTickets.Core.Model;

namespace CustomDataAuthenticationTickets.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string GetExta(UserData userData)
        {
            
            return userData.FirstName + ", " +userData.LastName;
        }
    }
}
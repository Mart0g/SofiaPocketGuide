using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";

            return View();
        }
        public ActionResult Chat()
        {
            ViewBag.Title = "Chat";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Title = "About";

            return View();
        }
    }
}

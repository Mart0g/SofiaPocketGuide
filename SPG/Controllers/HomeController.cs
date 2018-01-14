using SPG.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPG.Controllers
{
    public class HomeController : Controller
    {
        //IDataService dataService;
        public HomeController ():base()
        {
            //this.dataService = dataService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Chat()
        {
            ViewBag.Title = "Chat";

            return View();
        }
    }
}

﻿using SPG.DataService;
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
            ViewBag.Title = "Home";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";

            return View();
        }
    }
}

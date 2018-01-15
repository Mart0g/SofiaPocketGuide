using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPG.Controllers
{
    public class MessagesController : Controller
    {
        public ActionResult Message(String message)
        {
            ViewBag.Question = message;

            return View(message);
        }
	}
}
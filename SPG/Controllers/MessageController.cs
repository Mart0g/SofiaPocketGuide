using SPG.DataService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPG.Controllers
{
    public class MessageController : Controller
    {
        private readonly ChatService chatService;

        public MessageController()
        {
            this.chatService = new ChatService(new DataAccess.DataAccessService());
        }

        public MessageController(ChatService chatService)
        {
            this.chatService = chatService;
        }   

        public ActionResult Message(String message)
        {
            ViewBag.Question = message;

            return View(message);
        }
	}
}
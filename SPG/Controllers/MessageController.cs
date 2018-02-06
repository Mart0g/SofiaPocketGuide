using SPG.DataService.Services;
using SPG.DataViewModels.ViewModels;
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

        public ActionResult Message()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(MessageDTO model)
        {
            if (ModelState.IsValid)
            {
                //TODO: SubscribeUser(model.Email);
            }

            return View("Message", model);
        }
	}
}
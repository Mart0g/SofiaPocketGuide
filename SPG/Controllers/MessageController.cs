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
        private readonly MessageService chatService;

        public MessageController()
        {
            this.chatService = new MessageService(new DataAccess.DataAccessService());
        }

        public MessageController(MessageService chatService)
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
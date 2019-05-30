using SPG.DataAccess;
using SPG.DataService.Interfaces;
using SPG.DataService.Services;
using SPG.Domain.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SPG.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        List<MessageDTO> messages = new List<MessageDTO>();
        private static HistoryDTO history = new HistoryDTO();
        public MessageController()
        {
            this.messageService = new MessageService(new DataAccessService());
        }

        public MessageController(MessageService messageService)
        {
            this.messageService = messageService;
        }

        public ActionResult Message()
        {
            history.History = new List<MessageDTO>();
            history.CurrentMessage = new MessageDTO();
            history.History.AddRange(messages);
            return View(history);
        }

        [HttpPost]
        public ActionResult ShowMessage(HistoryDTO model)
        {
            string response = this.messageService.GetResponse(model.CurrentMessage.Message);
            model.CurrentMessage.CreatedOn = DateTime.Now;
            model.CurrentMessage.Type = MessageType.User;
            history.History.Add(model.CurrentMessage);
            history.History.Add(new MessageDTO() { UserName = "SPG", Message = response, Type= MessageType.Bot, CreatedOn=DateTime.Now });
            history.CurrentMessage = new MessageDTO();
            ModelState.Clear();
            return View("Message", history);
        }
    }
}
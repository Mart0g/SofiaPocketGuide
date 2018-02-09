using SPG.DataService.Services;
using SPG.DataViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Word2Vec.Net;

namespace SPG.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageService messageService;
        List<MessageDTO> messages = new List<MessageDTO>();
        private static HistoryDTO history = new HistoryDTO();
        public MessageController()
        {
            this.messageService = new MessageService(new DataAccess.DataAccessService());
        }

        public MessageController(MessageService messageService)
        {
            this.messageService = messageService;
        }   

        public ActionResult Message()
        {
            history.History = new List<MessageDTO>();
            history.Current = new MessageDTO();
            history.History.AddRange(messages);
            return View(history);
        }

        [HttpPost]
        public ActionResult ShowMessage(HistoryDTO model)
        {
            BestWord[] words = this.messageService.GetConnectedWords(model.Current.Message);
            history.History.Add(model.Current);
            
            history.Current = new MessageDTO();
            ModelState.Clear();
            return View("Message", history);
        }
	}
}
using SPG.DataAccess;
using SPG.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataService.Services
{
    public class MessageService : BaseService, IMessageService
    {
        public MessageService(DataAccessService dataAccessService) : base(dataAccessService)
        {

        }
    }
}

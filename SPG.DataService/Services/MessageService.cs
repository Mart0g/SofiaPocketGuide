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

        void SetWord2VecVocabulary()
        {
            
            string trainFile = @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\Word2VecFiles\user-venue-dataset.txt";
            
        }

    }
}

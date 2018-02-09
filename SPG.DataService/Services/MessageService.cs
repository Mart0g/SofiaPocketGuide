using SPG.DataAccess;
using SPG.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word2Vec.Net;

namespace SPG.DataService.Services
{
    public class MessageService : BaseService, IMessageService
    {
        private readonly Distance distanceFinder;

        public MessageService(DataAccessService dataAccessService) : base(dataAccessService)
        {
            string outputFile= @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\Word2VecFiles\vector.txt";
            distanceFinder = new Distance(outputFile);
        }

        public BestWord[] GetConnectedWords(string word)
        {
            foreach (var item in distanceFinder.Search(word))
            {
                string m = item.Word;
            }
            return distanceFinder.Search(word);
        }

        void SetWord2VecVocabulary()
        {
            
            string trainFile = @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\Word2VecFiles\user-venue-dataset.txt";
            
        }

    }
}

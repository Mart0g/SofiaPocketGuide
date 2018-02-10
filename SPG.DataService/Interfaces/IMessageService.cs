using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word2vec.Tools;
using Word2Vec.Net;

namespace SPG.DataService.Interfaces
{
    public interface IMessageService
    {   
        string GetResponse(string message);
    }
}

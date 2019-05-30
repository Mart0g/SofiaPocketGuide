using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Domain.Interfaces.Services
{
    public interface ITransformable
    {
        void TrainModel();
        string[] GetConnectedWords(string word);
    }
}

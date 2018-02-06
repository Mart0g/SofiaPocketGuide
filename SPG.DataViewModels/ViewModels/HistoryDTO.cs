using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataViewModels.ViewModels
{
    public class HistoryDTO
    {
        public List<MessageDTO> History { get; set; }

        public MessageDTO Current { get; set; }
    }
}

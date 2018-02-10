using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataViewModels.ViewModels
{
    public class MessageDTO
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public MessageType Type { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public enum MessageType
    {
        User = 1,
        Bot = 2
    }
}

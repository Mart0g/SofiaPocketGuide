using System.Collections.Generic;

namespace SPG.Domain.Models.ViewModels
{
    public class HistoryDTO
    {
        public List<MessageDTO> History { get; set; }

        public MessageDTO CurrentMessage { get; set; }

        public MessageDTO CurrentResponse { get; set; }
    }
}

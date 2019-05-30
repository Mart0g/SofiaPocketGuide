using System;

namespace SPG.Domain.Models.ViewModels
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

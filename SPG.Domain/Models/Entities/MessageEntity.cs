using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Domain.Models.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime SendOn { get; set; }

    }
}

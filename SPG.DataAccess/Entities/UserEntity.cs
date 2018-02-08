using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public virtual List<VenueEntity> Venues { get; set; }
    }
}

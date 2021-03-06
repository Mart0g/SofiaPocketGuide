﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Domain.Models.Entities
{
    public class VenueEntity
    {
        public int Id { get; set; }
        public int VenueCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual List<TagEntity> Tags { get; set; }
        public virtual List<UserEntity> Users { get; set; }
    }
}

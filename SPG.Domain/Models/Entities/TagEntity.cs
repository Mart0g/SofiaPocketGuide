﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Domain.Models.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual List<VenueEntity> Venues { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Entities
{
    public class SubCategoryEntity
    {
        public int Id { get; set; }
        public NeedCategoryEntity NeedCategory { get; set; }
        public PlaceCategoryEntity PlaceCategory { get; set; }
        public string Value { get; set; }

    }
}

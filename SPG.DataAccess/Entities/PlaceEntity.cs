using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Entities
{
    public class PlaceEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public PlaceCategoryEntity Category { get; set; }
        public SubCategoryEntity SubCategory { get; set; }
    }
}

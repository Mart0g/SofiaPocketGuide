using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Entities
{
    public class WordEntity
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public LexicalCategoryEntity LexicalCategory { get; set; }
        public NeedCategoryEntity NeedCategory { get; set; }
        public PlaceCategoryEntity PlaceCategory { get; set; }
        public double ConfidenceLevel { get; set; }

    }
}

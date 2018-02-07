using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Entities
{
    public class WordEntity
    {
        public int Id { get; set; }
        public string Word { get; set; }

        [ForeignKey("Need")]
        public int NeedId { get; set; }
        public NeedEntity Need { get; set; }

        [ForeignKey("Tag")]
        public int TagId { get; set; }
        public TagEntity Tag { get; set; }

        public double ConfidenceLevel { get; set; }

    }
}

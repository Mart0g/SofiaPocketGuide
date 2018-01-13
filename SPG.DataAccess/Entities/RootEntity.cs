using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Entities
{
    public class RootEntity
    {
        public int Id { get; set; }
        public string Root { get; set; }
        public List<string> Preffixes { get; set; }
        public List<string> Suffixess { get; set; }
    }
}

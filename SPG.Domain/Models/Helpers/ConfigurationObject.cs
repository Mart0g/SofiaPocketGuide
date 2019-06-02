using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Domain.Models.Helpers
{
    public class ConfigurationObject
    {
        public string ConnectionString { get; set; }

        public string TagVenueFile { get; set; }
        public string UserVenueFile { get; set; }
        public string TipVenueFile { get; set; }
        public string PrefixFile { get; set; }
        public string SuffixFile { get; set; }

        public string TrainFile { get; set; }
        public string OutputFile { get; set; }
        public string VocabularyFile { get; set; }
    }
}

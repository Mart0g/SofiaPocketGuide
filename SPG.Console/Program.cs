using SPG.DataAccess;
using SPG.Domain.Models.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string datasetDirectory = Directory.GetCurrentDirectory() + @"\DataSets\";
            string word2vecDirectory = Directory.GetCurrentDirectory() + @"\Word2VecFiles\";

            ConfigurationObject configuration = new ConfigurationObject()
            {
                ConnectionString = "name=SPG.DataAccess2",
                TagVenueFile = datasetDirectory + "tag-venue-dataset.txt",
                TipVenueFile = datasetDirectory + "tip-venue-dataset.txt",
                UserVenueFile = datasetDirectory + "user-venue-dataset.txt",
                PrefixFile = datasetDirectory + "prefix-dataset.txt",
                SuffixFile = datasetDirectory + "suffix-dataset.txt",
                TrainFile = word2vecDirectory + "source-word-2-vec-file.txt",
                OutputFile = word2vecDirectory + "vector.txt",
                VocabularyFile = word2vecDirectory + "vocub.txt"
            };
            System.Console.WriteLine("Initialization started!");
            DataContext dc = new DataContext(configuration.ConnectionString);
            DataContextInitializer dci = new DataContextInitializer(configuration);
            dci.InitializeDatabase(dc);
            System.Console.WriteLine("Done!");
        }
    }
}

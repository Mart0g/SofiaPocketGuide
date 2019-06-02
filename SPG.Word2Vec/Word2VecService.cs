using SPG.Domain.Interfaces.Services;
using SPG.Domain.Models.Helpers;
using System;
using System.IO;
using System.Linq;
using Word2vec.Tools;
using Word2Vec.Net;


namespace SPG.Word2Vec
{
    public class Word2VecService : ITransformable
    {
        public ConfigurationObject Configuration { get; set; }
        public IDataAccessService DataAccessService { get; set; }
        public Vocabulary Vocabulary { get; set; }

        public Word2VecService(ConfigurationObject configuration, IDataAccessService dataAccessService)
        {
            Configuration = configuration;
            DataAccessService = dataAccessService;
            
        }

        public string[] GetConnectedWords(string word)
        {
            if (Vocabulary == null) Vocabulary = new Word2VecTextReader().Read(Configuration.VocabularyFile);
            DistanceTo[] words = Vocabulary.Distance(word, 20);
            return words.Select(w => w.Representation.WordOrNull).ToArray();
        }

        public void TrainModel()
        {
            string trainFile = Configuration.TrainFile;
            string outputFile = Configuration.OutputFile;
            string vocabFile = Configuration.VocabularyFile;

            if (!File.Exists(outputFile) && !File.Exists(vocabFile) && File.Exists(trainFile))
            {
                var word2Vec = Word2VecBuilder.Create()
                .WithTrainFile(trainFile)
                .WithOutputFile(outputFile)
                .WithSize(200)
                .WithSaveVocubFile(vocabFile)
                .Build();

                word2Vec.TrainModel();
            }
        }
    }
}

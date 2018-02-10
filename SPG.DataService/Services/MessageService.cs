using SPG.DataAccess;
using SPG.DataAccess.Entities;
using SPG.DataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word2vec.Tools;
using Word2Vec.Net;

namespace SPG.DataService.Services
{
    public class MessageService : BaseService, IMessageService
    {
        private readonly Vocabulary vocabulary;

        public MessageService(DataAccessService dataAccessService) : base(dataAccessService)
        {
            string outputFile = @"C:\Users\dido_\Documents\GitHub\SofiaPocketGuide\SPG.DataAccess\Word2VecFiles\vector.txt";
            vocabulary = new Word2VecTextReader().Read(outputFile);
        }

        public string[] GetConnectedWords(string word)
        {
            DistanceTo[] words = vocabulary.Distance(word, 20);
            return words.Select(w => w.Representation.WordOrNull).ToArray();
        }

        public string GetResponse(string message)
        {
            string[] words = message.Split(' ', ',', '.', '\'', '?', '!', '/', '\\', ')', '(', ';', ':', '-', '_', '@', '#', '"', '+');
            string[] tags = GetTagsFromDataBase(words);
            if (!tags.Any())
                tags = GetTagsFromWord2VecLogic(words);
            if (!tags.Any())
                return $"I don't understand your question. Can you be more specific? :)";
            List<VenueEntity> intersection = new List<VenueEntity>();
            foreach (string tag in tags)
            {
                List<VenueEntity> venues = DataAccessService.VenueRepository.GetVenuesWithUsers(tag);
                if (intersection.Count == 0)
                {
                    intersection = venues;
                }
                intersection = venues.Intersect(intersection).ToList();
            }
            if (intersection.Count != 0)
            {
                int maxValue = intersection.Max(v => v.Users.Count);
                VenueEntity final = intersection.Where(v => v.Users.Count == maxValue).FirstOrDefault();
                return $"We recommend this venue: {final.VenueCode} with {final.Users.Count} total visits!";
            }
            return $"I don't understand your question. Can you be more specific? :)";
        }


        private string[] GetTagsFromDataBase(string[] words)
        {
            List<string> foundTags = new List<string>();
            foreach (string word in words)
            {
                if (this.DataAccessService.TagRepository.CheckWordInTags(word))
                {
                    foundTags.Add(word);
                }
            }
            return foundTags.ToArray();
        }

        private string[] GetTagsFromWord2VecLogic(string[] words)
        {
            List<string> references = new List<string>();
            foreach (string word in words)
            {
                references.AddRange(GetConnectedWords(word));
            }
            return GetTagsFromDataBase(references.ToArray());
        }
    }
}

using SPG.DataAccess;
using SPG.DataService.Interfaces;
using SPG.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word2vec.Tools;

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
                return "I don't understand your question. Can you be more specific? :)";
            List<VenueEntity> minTags = new List<VenueEntity>();
            foreach (string tag in tags)
            {
                List<VenueEntity> venues = DataAccessService.VenueRepository.GetVenuesWithUsers(tag);
                if (minTags.Count == 0)
                {
                    minTags = venues;
                }
                if (minTags.Count > venues.Count)
                {
                    minTags = venues;
                }
            }
            if (minTags.Count != 0)
            {
                int maxValue = minTags.Max(v => v.Users.Count);
                VenueEntity final = minTags.Where(v => v.Users.Count == maxValue).FirstOrDefault();
                string recommended = GetRecommendedMeals(final.Tags, words);
                if (String.IsNullOrWhiteSpace(recommended))
                    recommended = "none";
                return "SPG recommends this venue: " + final.VenueCode + "!\n Tags: " + recommended + "\n Visits: " + final.Users.Count;
            }
            return "I don't understand your question. Can you be more specific? :)";
        }

        private string GetRecommendedMeals(List<TagEntity> tags, string[] words)
        {
            StringBuilder sb = new StringBuilder();
            foreach (TagEntity tag in tags)
            {
                foreach (string word in words)
                {
                    if ((tag.Value.ToLower().Contains(word.ToLower())
                        || tag.Value.ToLower() == word.ToLower())
                        && !sb.ToString().Contains(tag.Value))
                    {
                        sb.Append(tag.Value).Append(", ");
                    }
                }
            }
            if (sb.Length > 3)
                sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        private string[] GetTagsFromDataBase(string[] words)
        {
            List<string> foundTags = new List<string>();
            foreach (string word in words)
            {
                foundTags.AddRange(DataAccessService.TagRepository.CheckWordInTags(word));
                foundTags.AddRange(DataAccessService.TagRepository.CheckWordWithMorphemes(word));
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

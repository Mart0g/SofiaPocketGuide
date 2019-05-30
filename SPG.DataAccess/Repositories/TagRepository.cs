using SPG.Domain.Interfaces.Repositories;
using SPG.Domain.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SPG.DataAccess.Repositories
{
    public class TagRepository : ITagRepository
    {
        public TagRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(TagEntity entity)
        {
            Context.Tag.Add(entity);
        }

        public List<string> CheckWordInTags(string word)
        {
            return Context.Tag.Where(
                t => (t.Value.ToLower() == word.ToLower()
                || t.Value.ToLower().EndsWith(" " + word.ToLower())
                || t.Value.ToLower().StartsWith(word.ToLower() + " ")
                || t.Value.ToLower().Contains(" " + word.ToLower() + " "))).Select(t => t.Value).ToList();
        }
        public List<string> CheckWordWithMorphemes(string word)
        {
            List<string> tags = new List<string>();
            List<PrefixEntity> prefixes = Context.Prefix.ToList();
            List<SuffixEntity> suffixes = Context.Suffix.ToList();
            foreach (PrefixEntity prefix in prefixes)
            {
                tags.AddRange(Context.Tag.Where(
                t => (t.Value.ToLower() == prefix.Value.ToLower() + word.ToLower())).Select(t => t.Value));
            }
            foreach (SuffixEntity suffix in suffixes)
            {
                tags.AddRange(Context.Tag.Where(
                t => (t.Value.ToLower() == word.ToLower() + suffix.Value.ToLower())).Select(t => t.Value));
            }

            return tags;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public TagEntity Get(int id)
        {
            return Context.Tag.Where(pc => pc.Id == id).FirstOrDefault();
        }

        public IEnumerable<TagEntity> GetAll()
        {
            return Context.Tag;
        }

        public void Remove(TagEntity entity)
        {
            Context.Tag.Remove(entity);
        }

        public void Update(TagEntity entity)
        {
            TagEntity tag = Get(entity.Id);
            tag.Value = entity.Value;
            Context.SaveChanges();
        }
    }
}

using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

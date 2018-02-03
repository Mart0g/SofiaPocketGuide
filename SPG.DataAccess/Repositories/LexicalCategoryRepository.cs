using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Repositories
{
    public class LexicalCategoryRepository : ILexicalCategoryRepository
    {
        public LexicalCategoryRepository(DataContext context)
        {
            Context = context;
        }
        public DataContext Context { get; set; }

        public void Add(LexicalCategoryEntity entity)
        {
            Context.LexicalCategory.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public LexicalCategoryEntity Get(int id)
        {
            return Context.LexicalCategory.Where(lc => lc.Id == id).FirstOrDefault();
        }

        public IEnumerable<LexicalCategoryEntity> GetAll()
        {
            return Context.LexicalCategory;
        }

        public void Remove(LexicalCategoryEntity entity)
        {
            Context.LexicalCategory.Remove(entity);
        }

        public void Update(LexicalCategoryEntity entity)
        {
            LexicalCategoryEntity lexicalCategory = Get(entity.Id);
            lexicalCategory.Value = entity.Value;
            Context.SaveChanges();
        }
    }
}

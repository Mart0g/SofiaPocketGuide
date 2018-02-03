using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Repositories
{
    public class WordRepository : IWordRepository
    {
        public WordRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(WordEntity entity)
        {
            Context.Word.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public WordEntity Get(int id)
        {
            return Context.Word.Where(w => w.Id == id).FirstOrDefault();
        }

        public IEnumerable<WordEntity> GetAll()
        {
            return Context.Word;
        }

        public void Remove(WordEntity entity)
        {
            Context.Word.Remove(entity);
        }

        public void Update(WordEntity entity)
        {
            WordEntity word = Get(entity.Id);
            word.Word = entity.Word;
            Context.SaveChanges();
        }
    }
}

using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Repositories
{
    public class RootRepository : IRootRepository
    {
        public RootRepository(DataContext context)
        {
            Context = context;
        }
        public DataContext Context { get; set; }

        public void Add(RootEntity entity)
        {
            Context.Root.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public RootEntity Get(int id)
        {
            return Context.Root.Where(r => r.Id == id).FirstOrDefault();
        }

        public IEnumerable<RootEntity> GetAll()
        {
            return Context.Root;
        }

        public void Remove(RootEntity entity)
        {
            Context.Root.Remove(entity);
        }

        public void Update(RootEntity entity)
        {
            RootEntity root = Get(entity.Id);
            root.Preffixes = entity.Preffixes;
            root.Suffixess = entity.Suffixess;
            Context.SaveChanges();
        }
    }
}

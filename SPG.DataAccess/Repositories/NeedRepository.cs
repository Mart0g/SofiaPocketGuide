using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Repositories
{
    public class NeedRepository : INeedRepository
    {
        public NeedRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(NeedEntity entity)
        {
            Context.Need.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public NeedEntity Get(int id)
        {
            return Context.Need.Where(nc => nc.Id == id).FirstOrDefault();
        }

        public IEnumerable<NeedEntity> GetAll()
        {
            return Context.Need;
        }

        public void Remove(NeedEntity entity)
        {
            Context.Need.Remove(entity);
        }

        public void Update(NeedEntity entity)
        {
            NeedEntity needCategory = Get(entity.Id);
            needCategory.Value = entity.Value;
            Context.SaveChanges();
        }
    }
}

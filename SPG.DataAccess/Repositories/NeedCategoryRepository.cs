using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Repositories
{
    public class NeedCategoryRepository : INeedCategoryRepository
    {
        public NeedCategoryRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(NeedCategoryEntity entity)
        {
            Context.NeedCategory.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public NeedCategoryEntity Get(int id)
        {
            return Context.NeedCategory.Where(nc => nc.Id == id).FirstOrDefault();
        }

        public IEnumerable<NeedCategoryEntity> GetAll()
        {
            return Context.NeedCategory;
        }

        public void Remove(NeedCategoryEntity entity)
        {
            Context.NeedCategory.Remove(entity);
        }

        public void Update(NeedCategoryEntity entity)
        {
            NeedCategoryEntity needCategory = Get(entity.Id);
            needCategory.Value = entity.Value;
            Context.SaveChanges();
        }
    }
}

using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        public SubCategoryRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(SubCategoryEntity entity)
        {
            Context.SubCategory.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public SubCategoryEntity Get(int id)
        {
            return Context.SubCategory.Where(sb => sb.Id == id).FirstOrDefault();
        }

        public IEnumerable<SubCategoryEntity> GetAll()
        {
            return Context.SubCategory;
        }

        public void Remove(SubCategoryEntity entity)
        {
            Context.SubCategory.Remove(entity);
        }

        public void Update(SubCategoryEntity entity)
        {
            SubCategoryEntity subCategory = Get(entity.Id);
            subCategory.Value = entity.Value;
            Context.SaveChanges();
        }
    }
}

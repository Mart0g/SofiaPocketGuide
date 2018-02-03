using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Repositories
{
    public class PlaceCategoryRepository : IPlaceCategoryRepository
    {
        public PlaceCategoryRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(PlaceCategoryEntity entity)
        {
            Context.PlaceCategory.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public PlaceCategoryEntity Get(int id)
        {
            return Context.PlaceCategory.Where(pc => pc.Id == id).FirstOrDefault();
        }

        public IEnumerable<PlaceCategoryEntity> GetAll()
        {
            return Context.PlaceCategory;
        }

        public void Remove(PlaceCategoryEntity entity)
        {
            Context.PlaceCategory.Remove(entity);
        }

        public void Update(PlaceCategoryEntity entity)
        {
            PlaceCategoryEntity placeCategory = Get(entity.Id);
            placeCategory.Value = entity.Value;
            Context.SaveChanges();
        }
    }
}

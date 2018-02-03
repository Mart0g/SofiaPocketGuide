using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        public PlaceRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(PlaceEntity entity)
        {
            Context.Place.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public PlaceEntity Get(int id)
        {
            return Context.Place.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<PlaceEntity> GetAll()
        {
            return Context.Place;
        }

        public void Remove(PlaceEntity entity)
        {
            Context.Place.Remove(entity);
        }

        public void Update(PlaceEntity entity)
        {
            PlaceEntity place = Get(entity.Id);
            place.Name = entity.Name;
            Context.SaveChanges();
        }
    }
}

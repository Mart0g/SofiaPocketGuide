using SPG.DataAccess.Entities;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        public VenueRepository(DataContext context)
        {
            Context = context;
        }

        public DataContext Context { get; set; }

        public void Add(VenueEntity entity)
        {
            Context.Venue.Add(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public VenueEntity Get(int id)
        {
            return Context.Venue.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<VenueEntity> GetAll()
        {
            return Context.Venue;
        }

        public void Remove(VenueEntity entity)
        {
            Context.Venue.Remove(entity);
        }

        public void Update(VenueEntity entity)
        {
            VenueEntity place = Get(entity.Id);
            place.Name = entity.Name;
            Context.SaveChanges();
        }
    }
}

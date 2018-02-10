using SPG.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Interfaces
{
    public interface IVenueRepository: IDisposable, IBaseRepository<VenueEntity>
    {
        List<VenueEntity> GetVenuesWithUsers(string tag);
    }
}

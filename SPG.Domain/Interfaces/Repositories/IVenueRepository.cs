using System;
using System.Collections.Generic;
using SPG.Domain.Models.Entities;


namespace SPG.Domain.Interfaces.Repositories
{
    public interface IVenueRepository: IDisposable, IBaseRepository<VenueEntity>
    {
        List<VenueEntity> GetVenuesWithUsers(string tag);
    }
}

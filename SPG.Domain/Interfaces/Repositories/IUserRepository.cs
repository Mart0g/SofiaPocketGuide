using System;
using SPG.Domain.Models.Entities;

namespace SPG.Domain.Interfaces.Repositories
{
    public interface IUserRepository: IDisposable, IBaseRepository<UserEntity>
    {
    }
}

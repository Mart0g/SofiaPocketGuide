using System;
using SPG.Domain.Models.Entities;

namespace SPG.Domain.Interfaces.Repositories
{
    public interface IMessageRepository: IDisposable, IBaseRepository<MessageEntity>
    {
    }
}

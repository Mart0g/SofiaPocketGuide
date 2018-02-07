using SPG.DataAccess;
using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess
{
    public interface IDataAccessService
    {
        IMessageRepository MessageRepository { get; set; }
        INeedRepository NeedRepository { get; set; }
        ITagRepository TagRepository { get; set; }
        IVenueRepository VenueRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IWordRepository WordRepository { get; set; }

    }
}

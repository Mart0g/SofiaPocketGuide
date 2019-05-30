using SPG.Domain.Interfaces.Repositories;

namespace SPG.Domain.Interfaces.Services
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

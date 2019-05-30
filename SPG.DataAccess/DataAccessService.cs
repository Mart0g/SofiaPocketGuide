using SPG.Domain.Interfaces.Repositories;
using SPG.Domain.Interfaces.Services;
using SPG.DataAccess.Repositories;
using SPG.DataAccess.Unit;

namespace SPG.DataAccess
{
    public class DataAccessService : IDataAccessService, IUnitOfWork
    {

        public DataAccessService()
        {
            DataContext context = new DataContext();
            Context = context;
            MessageRepository = new MessageRepository(context);
            NeedRepository = new NeedRepository(context);
            TagRepository = new TagRepository(context);
            VenueRepository = new VenueRepository(context);
            UserRepository = new UserRepository(context);
            WordRepository = new WordRepository(context);
        }

        public DataContext Context { get; set; }
        public IMessageRepository MessageRepository { get; set; }
        public INeedRepository NeedRepository { get; set; }
        public ITagRepository TagRepository { get; set; }
        public IVenueRepository VenueRepository { get; set; }
        public IWordRepository WordRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public void Commit()
        {
            Context.Database.CurrentTransaction.Commit();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Rollback()
        {
            Context.Database.CurrentTransaction.Rollback();
        }
    }
}

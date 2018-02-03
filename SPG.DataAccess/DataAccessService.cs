using SPG.DataAccess;
using SPG.DataAccess.Interfaces;
using SPG.DataAccess.Repositories;
using SPG.DataAccess.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess
{
    public class DataAccessService : IDataAccessService, IUnitOfWork
    {

        public DataAccessService()
        {
            DataContext context = new DataContext();
            Context = context;
            LexicalCategoryRepository = new LexicalCategoryRepository(context);
            MessageRepository = new MessageRepository(context);
            NeedCategoryRepository = new NeedCategoryRepository(context);
            PlaceCategoryRepository = new PlaceCategoryRepository(context);
            PlaceRepository = new PlaceRepository(context);
            RootRepository = new RootRepository(context);
            SubCategoryRepository = new SubCategoryRepository(context);
            WordRepository = new WordRepository(context);
        }

        public DataContext Context { get; set; }
        public ILexicalCategoryRepository LexicalCategoryRepository { get; set; }
        public IMessageRepository MessageRepository { get; set; }
        public INeedCategoryRepository NeedCategoryRepository { get; set; }
        public IPlaceCategoryRepository PlaceCategoryRepository { get; set; }
        public IPlaceRepository PlaceRepository { get; set; }
        public IRootRepository RootRepository { get; set; }
        public ISubCategoryRepository SubCategoryRepository { get; set; }
        public IWordRepository WordRepository { get; set; }

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

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
        ILexicalCategoryRepository LexicalCategoryRepository { get; set; }
        IMessageRepository MessageRepository { get; set; }
        INeedCategoryRepository NeedCategoryRepository { get; set; }
        IPlaceCategoryRepository PlaceCategoryRepository { get; set; }
        IPlaceRepository PlaceRepository { get; set; }
        IRootRepository RootRepository { get; set; }
        ISubCategoryRepository SubCategoryRepository { get; set; }
        IWordRepository WordRepository { get; set; }

    }
}

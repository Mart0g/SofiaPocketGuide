using SPG.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Interfaces
{
    public interface ILexicalCategoryRepository: IDisposable, IBaseRepository<LexicalCategoryEntity>
    {
    }
}

using SPG.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPG.DataAccess.Unit
{
    public interface IUnitOfWork
    {
        //IBaseRepository<T> Repository<T>() where T : class;
        void Commit();
        void Rollback();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SPG.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {

        void Add(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Remove(T entity);
    }
}

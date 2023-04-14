using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactAPI.DataAccess
{
    public interface IContactDataAccess<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        bool Add(T entity);
        bool AddRange(IEnumerable<T> entities);
        bool Update(T entity);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);
        bool SaveChanges();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyColours.Website.Core.Common
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void CreateMany(IEnumerable<T> entities);

        void Delete(T entity);
        void DeleteMany(IEnumerable<T> entities);

        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    }
}

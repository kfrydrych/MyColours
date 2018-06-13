using MyColours.Website.Core.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MyColours.Website.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public void CreateMany(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public void DeleteMany(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }
        public virtual T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().AsEnumerable();
        }
    }
}
using notebook.core.models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace notebook.core.data
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        T Get(long id, params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        List<T> GetList(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

}

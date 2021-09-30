using System;
using System.Collections.Generic;
using System.Text;

namespace notebook.core.data
{
    public interface IService<T> where T : class
    {
        T Get(long id);
        List<T> GetList();
        void AddOrUpdate(T entity);
        void Delete(long id);
    }

}

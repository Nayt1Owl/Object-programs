using System;
using System.Collections.Generic;

namespace Proggs1._1
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T Read(int id);
        List<T> ReadAll();
        void Update(T entity);
        void Delete(int id);
    }
}

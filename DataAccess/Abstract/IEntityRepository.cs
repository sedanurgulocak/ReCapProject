using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T>
    { 
        List<T> GetAll();
        T GetById(int entity);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}

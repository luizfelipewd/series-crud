using System.Collections.Generic;

namespace seriescrud.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T returnById(int id);
        void Insert(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int nextId();
    }
}
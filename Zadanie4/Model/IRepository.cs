using System.Linq;

namespace Model
{
    interface IRepository<T>
    {
        bool Add(T item);
        bool Delete(T item);
        bool Update(T item);
        T Get(int id);
        IQueryable<T> GetAll();
    }
}

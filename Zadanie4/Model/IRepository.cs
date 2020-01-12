using System.Linq;

namespace Model
{
    interface IRepository<T>
    {
        bool Add(T item);
        void Delete(int Id);
        bool Update(T item);
        T Get(int id);
        IQueryable<T> GetAll();
    }
}

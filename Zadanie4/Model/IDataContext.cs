using System.Linq;

namespace Model
{
    public interface IDataContext<T>
    {
        IQueryable<T> GetItems();
        bool Add(T item);
        bool Update(T item);
        bool Delete(T item);
        T Get(int id);
    }
}

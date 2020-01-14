using System.Collections.Generic;
using System.Linq;

namespace Data
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

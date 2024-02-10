using System.Linq.Expressions;

namespace EmployeeEclipe.FactoryDesign
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        T GETFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> item);

    }
}

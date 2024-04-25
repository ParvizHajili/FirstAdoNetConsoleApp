using FirstAdoNetConsoleApp.Entities.Abstract;

namespace FirstAdoNetConsoleApp.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : class, new()
    {
        T Get(int id);
        List<T> Get();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

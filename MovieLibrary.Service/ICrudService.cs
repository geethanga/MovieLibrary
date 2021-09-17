using System.Threading.Tasks;

namespace MovieLibrary.Service
{
    public interface ICrudService<T>
    {
        Task<T> Create(T entity);
        Task<T> Read(int id);
        T Update(T entity);
        void Delete(int id);
    }
}
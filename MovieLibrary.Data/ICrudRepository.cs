using System.Threading.Tasks;
using MovieLibrary.Models;

namespace MovieLibrary.Data
{
    public interface ICrudRepository<T>
    {
        Task<T> Create(T entity);
        Task<Movie> Read(int id);
        T Update(T entity);
        void Delete(int id);
    }
}
using System.Collections.Generic;
using MovieLibrary.Models;

namespace MovieLibrary.Data
{
    public interface IPersonRepository : ICrudRepository<Person>
    {
        IList<Movie> GetMovies(int id);
    }
}
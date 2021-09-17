using System.Collections.Generic;
using MovieLibrary.Models;

namespace MovieLibrary.Data
{
    public interface IMovieRepository : ICrudRepository<Movie>
    {
        IList<Movie> GetMoviesByYear(int year);
        IList<Movie> GetMoviesByRating(int rating);
        IList<Movie> GetMoviesByTitle(string title);
    }
}
using System.Collections.Generic;
using MovieLibrary.Models;

namespace MovieLibrary.Service
{
    public interface IMovieService : ICrudService<Movie>
    {
        IList<Movie> GetLatestMovies();
        IList<Movie> GetTopRatedMovies();
        Movie IncreaseRating(int id, int increment);
        Movie DecreaseRating(int id, int decrement);
    }
}
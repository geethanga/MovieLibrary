using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MovieLibrary.Data;
using MovieLibrary.Models;

namespace MovieLibrary.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<MovieService> _logger;
        private readonly DateTime _minReleaseDate = new DateTime(1900, 1, 1);

        public MovieService(IMovieRepository movieRepository, ILogger<MovieService> logger)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public Task<Movie> Create(Movie entity)
        {
            if (entity.Rating is > 10 or < 0)
            {
                _logger.LogError($"Provided rating : {entity.Rating} is out of range.");
                throw new InvalidOperationException("Rating is out of range");
            }

            if (entity.ReleaseDate < _minReleaseDate)
            {
                _logger.LogError("Invalid Release Date");
                throw new InvalidOperationException("Invalid Release Date");
            }
            
            return _movieRepository.Create(entity);
        }

        public Task<Movie> Read(int id)
        {
            return _movieRepository.Read(id);
        }

        public Movie Update(Movie entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Movie> GetLatestMovies()
        {
            throw new System.NotImplementedException();
        }

        public IList<Movie> GetTopRatedMovies()
        {
            throw new System.NotImplementedException();
        }

        public Movie IncreaseRating(int id, int increment)
        {
            throw new NotImplementedException();
        }

        public Movie DecreaseRating(int id, int decrement)
        {
            throw new NotImplementedException();
        }
    }
}
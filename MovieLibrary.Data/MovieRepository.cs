using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models;

namespace MovieLibrary.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieLibraryDbContext _dbContext;

        public MovieRepository(MovieLibraryDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        public async Task<Movie> Create(Movie entity)
        {
            _dbContext.Movies.Add(entity);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(entity).ReloadAsync();
            return entity;
        }

        public Task<Movie> Read(int id)
        {
            return _dbContext.Movies.SingleOrDefaultAsync(m => m.Id == id);
        }

        public Movie Update(Movie entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Movie> GetMoviesByYear(int year)
        {
            throw new System.NotImplementedException();
        }

        public IList<Movie> GetMoviesByRating(int rating)
        {
            throw new System.NotImplementedException();
        }

        public IList<Movie> GetMoviesByTitle(string title)
        {
            throw new System.NotImplementedException();
        }
    }
}
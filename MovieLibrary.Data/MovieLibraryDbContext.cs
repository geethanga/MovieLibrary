using Microsoft.EntityFrameworkCore;
using MovieLibrary.Models;

namespace MovieLibrary.Data
{
    public class MovieLibraryDbContext : DbContext
    {
        public MovieLibraryDbContext(DbContextOptions<MovieLibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<MoviePerson> MoviePersons { get; set; }
    }
}
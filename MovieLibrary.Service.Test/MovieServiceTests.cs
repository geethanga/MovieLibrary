using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using MovieLibrary.Data;
using MovieLibrary.Models;
using NUnit.Framework;

namespace MovieLibrary.Service.Test
{
    public class Tests
    {
        private IMovieService _movieService;
        private Mock<ILogger<MovieService>> _mockLogger;
        private Mock<IMovieRepository> _mockMovieRepository;
        
        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<MovieService>>();
            _mockMovieRepository = new Mock<IMovieRepository>();
            _movieService = new MovieService(_mockMovieRepository.Object, _mockLogger.Object);
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        public void CreatMovieWithValidParameters(int rating)
        {
            var movie = new Movie
            {
                Rating = rating,
                ReleaseDate = DateTime.Now
            };
            _mockMovieRepository.Setup(m => m.Create(movie)).Returns(Task.FromResult(movie));
                
            var createdMovie = _movieService.Create(movie);
            
            Assert.IsNotNull(createdMovie);
        }

        [TestCase(11)]
        [TestCase(-1)]
        public void CreateMovieWithInvalidRating(int rating)
        {
            var movie = new Movie
            {
                Rating = rating,
                ReleaseDate = DateTime.Now
            };
            _mockMovieRepository.Setup(m => m.Create(movie)).Returns(Task.FromResult(movie));
                
            var ex = Assert.Throws<InvalidOperationException>(() => _movieService.Create(movie));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Rating is out of range", ex.Message);
        }

        [Test]
        public void CreateMovieWithInvalidReleaseDate()
        {
            var movie = new Movie
            {
                Rating = 5,
                ReleaseDate = new DateTime(1899,1,1)
            };
            _mockMovieRepository.Setup(m => m.Create(movie)).Returns(Task.FromResult(movie));
                
            var ex = Assert.Throws<InvalidOperationException>(() => _movieService.Create(movie));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Invalid Release Date", ex.Message);
        }
    }
}
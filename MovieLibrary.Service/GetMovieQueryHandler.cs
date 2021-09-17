using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MovieLibrary.Data;
using MovieLibrary.Models;

namespace MovieLibrary.Service
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, Movie>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMovieQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        
        public Task<Movie> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            return _movieRepository.Read(request.Id);
        }
    }
}
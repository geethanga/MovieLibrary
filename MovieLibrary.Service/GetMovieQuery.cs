using MediatR;
using MovieLibrary.Models;

namespace MovieLibrary.Service
{
    public class GetMovieQuery : IRequest<Movie>
    {
        public int Id { get; set; }
    }
}
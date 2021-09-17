using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieLibrary.Models;
using MovieLibrary.Service;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;
        private readonly IMediator _mediator;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Movie movie)
        {
            try
            {
                var result = await _movieService.Create(movie);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("Error when saving movie");
                return Problem("An error has occured when fulfilling the POST request");
            }
        }
        
        [HttpGet("/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var request = new GetMovieQuery()
                {
                    Id = id
                };
                
                var result = await _mediator.Send(request);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error when getting movie");
                return Problem("An error has occured when fulfilling the GET request");
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Movie.Contracts;
using Movie.Core.DTOs;

namespace Movie.Api.Controllers;

[Route("api/movie")]
[ApiController]
public class MoviesController : ControllerBase
{
  //  private readonly MovieApiContext _context;
    private readonly IServiceManager _serviceManager;
    public MoviesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
     //   _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
    {
        var movies = await _serviceManager.MovieService.GetMoviesAsync();
        return Ok(movies);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieDto>> GetMovie(int id)
    {
        var movie = await _serviceManager.MovieService.GetMovieAsync(id);
        if (movie == null)
            return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult> CreateMovie(CreateMovieDto dto)
    {
        await _serviceManager.MovieService.CreateMovieAsync(dto);
        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteMovie(int id)
    {
        await _serviceManager.MovieService.DeleteMovieAsync(id);
        return Ok();
    }
    
    [HttpPatch]
    public async Task<ActionResult> UpdateMovie(UpdateMovieDto dto)
    {
        await _serviceManager.MovieService.UpdateMovieAsync(dto);
        return Ok();
    }
}
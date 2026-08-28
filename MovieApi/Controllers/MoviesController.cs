using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Models.DTOs;

namespace MovieApi.Controllers;

[Route("api/movie")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly MovieApiContext _context;
    public MoviesController(MovieApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
    {
        var movies = await _context.Movie.Select(m => new MovieDto()
        {
            Description = m.Description,
            Director = m.Director,
            DurationMinutes = m.DurationMinutes,
            Genre = m.Genre,
            Id = m.Id,
            Rating = m.Rating,
            ReleaseYear = m.ReleaseYear,
            Title = m.Title
        }).ToListAsync();
        return Ok(movies);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieDto>> GetMovie(int id)
    {
        var movie = await _context.Movie.Select(m => new MovieDto()
        {
            Description = m.Description,
            Director = m.Director,
            DurationMinutes = m.DurationMinutes,
            Genre = m.Genre,
            Id = m.Id,
            Rating = m.Rating,
            ReleaseYear = m.ReleaseYear,
            Title = m.Title
        }).FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null)
            return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<MovieDto>> CreateMovie(CreateMovieDto dto)
    {
        var movie = new Movie()
        {
            Description = dto.Description,
            Director = dto.Director,
            DurationMinutes = dto.DurationMinutes,
            Rating = dto.Rating,
            Title = dto.Title,
            ReleaseYear = dto.ReleaseYear,
            Genre = dto.Genre,
        };

        _context.Movie.Add(movie);
        await _context.SaveChangesAsync();
        return Ok(movie);
    }
}
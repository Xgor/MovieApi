using Microsoft.EntityFrameworkCore;
using Movie.Core.Contracts;
using Movie.Core.DTOs;
using Movie.Core.Models;

namespace Movie.Data.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MovieApiContext _context;
    public MovieRepository(MovieApiContext context)
    {
        _context = context;
    }
    
    public async void Create(MovieModel entity)
    {
        _context.Movie.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async void Delete(MovieModel entity)
    {
        _context.Movie.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MovieModel>> GetAllMovies()
    {
        return await _context.Movie.ToListAsync();
    }

    public async Task<MovieModel?> GetMovieById(int id)
    {
        return await _context.Movie.FindAsync(id);
    }
}
using Movie.Core.DTOs;

namespace Movie.Contracts;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetMoviesAsync(bool trackChanges = false);
    Task<MovieDto> GetMovieAsync(int id,bool trackChanges = false);
    Task CreateMovieAsync(CreateMovieDto dto);
    Task DeleteMovieAsync(int id);
    Task<MovieDto> UpdateMovieAsync(int id);
}

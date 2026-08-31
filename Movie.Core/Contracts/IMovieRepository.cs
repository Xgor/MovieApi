using Movie.Core.DTOs;
using Movie.Core.Models;

namespace Movie.Core.Contracts;

public interface IMovieRepository: IRepositoryBase<MovieModel>
{
    public Task<IEnumerable<MovieDto>> GetAllMovies();
    public Task<MovieDto> GetMovieById(int id);
}
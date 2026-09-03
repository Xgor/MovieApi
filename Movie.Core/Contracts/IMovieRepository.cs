using Movie.Core.Models;

namespace Movie.Core.Contracts;

public interface IMovieRepository: IRepositoryBase<MovieModel>
{
    public Task<IEnumerable<MovieModel>> GetAllMovies();
    public Task<MovieModel?> GetMovieById(int id);
    public Task<MovieModel?> GetMovieByTitle(string title);
}
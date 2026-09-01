using Movie.Core.Contracts;

namespace Movie.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private MovieApiContext _context;
    private Lazy<IMovieRepository> _movieRepository { get; set; }
    public IMovieRepository MovieRepository => _movieRepository.Value;

    public UnitOfWork(MovieApiContext context,Lazy<IMovieRepository> movieRepository)
    {
        _context = context;
        _movieRepository =  movieRepository;
    }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
}
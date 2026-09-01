using Movie.Core.Contracts;

namespace Movie.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MovieApiContext _context;
 //   private Lazy<IMovieRepository> _movieRepository;
    public IMovieRepository MovieRepository { get; }

    public UnitOfWork(MovieApiContext context,IMovieRepository movieRepository)
    {
        _context = context;
        MovieRepository =  movieRepository;
    }

    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
}
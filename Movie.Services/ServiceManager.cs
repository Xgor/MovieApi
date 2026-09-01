using Movie.Contracts;

namespace Movie.Services;

public class ServiceManager : IServiceManager
{
  //  private readonly Lazy<IMovieService> _movieService;
  //  public IMovieService MovieService => _movieService.Value;
  
    public IMovieService MovieService { get; }
    public ServiceManager(MovieService movieService)
    {
        MovieService = movieService;
    }
}
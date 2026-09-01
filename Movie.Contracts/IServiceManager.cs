namespace Movie.Contracts;

public interface IServiceManager
{
    IMovieService MovieService { get; }
}
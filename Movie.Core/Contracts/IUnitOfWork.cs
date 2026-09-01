namespace Movie.Core.Contracts;

public interface IUnitOfWork
{
    IMovieRepository MovieRepository { get; }

    Task<int> CompleteAsync();
}
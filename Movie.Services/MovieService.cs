using MapsterMapper;
using Movie.Contracts;
using Movie.Core.Contracts;
using Movie.Core.DTOs;

namespace Movie.Services;

public class MovieService : IMovieService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    public MovieService(IUnitOfWork uow,IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<MovieDto>> GetMoviesAsync(bool trackChanges = false)
    {
        var movies = await _uow.MovieRepository.GetAllMovies();
        return _mapper.Map<IEnumerable<MovieDto>>(movies);
    }

    public async Task<MovieDto> GetMovieAsync(int id, bool trackChanges = false)
    {
        throw new NotImplementedException();
    }

    public async Task CreateMovieAsync(CreateMovieDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteMovieAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<MovieDto> UpdateMovieAsync(int id)
    {
        throw new NotImplementedException();
    }
}
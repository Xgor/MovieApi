using Mapster;
using MapsterMapper;
using Movie.Contracts;
using Movie.Core.Contracts;
using Movie.Core.DTOs;
using Movie.Core.Models;

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

    public async Task<MovieDto?> GetMovieAsync(int id, bool trackChanges = false)
    {
        var movie = await _uow.MovieRepository.GetMovieById(id);
        if (movie == null) return null;
        return _mapper.Map<MovieDto>(movie);
//        throw new NotImplementedException();
    }

    public async Task CreateMovieAsync(CreateMovieDto dto)
    {
        MovieModel model = _mapper.Map<MovieModel>(dto);
        _uow.MovieRepository.Create(model);
        await _uow.CompleteAsync();
        //throw new NotImplementedException();
    }

    public async Task DeleteMovieAsync(int id)
    {
        var movie = await _uow.MovieRepository.GetMovieById(id);
        _uow.MovieRepository.Delete(movie);
        await _uow.CompleteAsync();
    }

    public async Task<MovieDto> UpdateMovieAsync(UpdateMovieDto dto)
    {
        var movie = await _uow.MovieRepository.GetMovieById(dto.Id);

        _mapper.Map(dto, movie);
        
        _uow.MovieRepository.Update(movie);
        await _uow.CompleteAsync();
        return _mapper.Map<MovieDto>(movie);
    }
}
using MovieCatalog.Application.DTO.Movie;

namespace MovieCatalog.Application.Services
{
	public interface IMovieService
	{
		Task<GetMovieDTO> AddMovie(AddMovieDTO addMovieDTO);
		Task DeleteMovie(int id);
		Task<IEnumerable<GetMovieDTO>> GetAllMovie();
		Task<GetMovieDTO> GetMovie(int id);
		Task UpdateMovie(UpdateMovieDTO updateMovieDTO);
	}
}
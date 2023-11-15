using Mapster;
using MovieCatalog.Application.DTO.Movie;
using MovieCatalog.Domain.Contracts;
using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Application.Services
{
	public class MovieService : IMovieService
	{
		private readonly IMovieRepository movieRepository;
		private readonly IUnitOfWork _unitOfWork;

		public MovieService(IMovieRepository movieRepository, IUnitOfWork unitOfWork)
		{
			this.movieRepository = movieRepository;
			this._unitOfWork = unitOfWork;
		}

		public async Task<GetMovieDTO> GetMovie(int id)
		{
			var result = await movieRepository.GetByIdAsync(id);
			return result.Adapt<GetMovieDTO>();
		}


		public async Task<IEnumerable<GetMovieDTO>> GetAllMovie()
		{
			var result = await movieRepository.GetAllAsync();
			return result.Adapt<IEnumerable<GetMovieDTO>>();
		}


		public async Task<GetMovieDTO> AddMovie(AddMovieDTO addMovieDTO)
		{
			var result = await movieRepository.AddAsync(addMovieDTO.Adapt<Movie>());
			await _unitOfWork.SaveChangesAsync();
			return result.Adapt<GetMovieDTO>();
		}

		public async Task DeleteMovie(int id)
		{
			await movieRepository.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task UpdateMovie(UpdateMovieDTO updateMovieDTO)
		{
			await movieRepository.UpdateAsync(updateMovieDTO.Adapt<Movie>());
			await _unitOfWork.SaveChangesAsync();
		}

	}
}

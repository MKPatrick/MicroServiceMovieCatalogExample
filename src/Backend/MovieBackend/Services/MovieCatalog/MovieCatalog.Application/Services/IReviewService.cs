using MovieCatalog.Application.DTO.Rating;

namespace MovieCatalog.Application.Services
{
	public interface IReviewService
	{
		Task<ICollection<RatingAverageDTO>> GetAverageRatingOfAllMovies();

		Task<RatingAverageDTO> GetAverageratingOfMovie(int ID);
	}
}
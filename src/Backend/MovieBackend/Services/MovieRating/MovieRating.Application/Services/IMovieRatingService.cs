using MovieRating.Application.DTO.MovieRating;

namespace MovieRating.Application.Services
{
	public interface IMovieRatingService
	{
		Task<GetMovieAverageRatingDTO> GetAverageRating(int MovieID);

		Task<IEnumerable<GetMovieAverageRatingDTO>> GetAllRatingsAverage();

		Task<IEnumerable<GetMovieRatingDTO>> GetRatingFromMovie(int ID);

		Task DeleteRatingsFromMovie(int MovieID);
	}
}
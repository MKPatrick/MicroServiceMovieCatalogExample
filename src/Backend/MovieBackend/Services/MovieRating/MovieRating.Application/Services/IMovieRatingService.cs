using MovieRating.Application.DTO.MovieRating;

namespace MovieRating.Application.Services
{
	public interface IMovieRatingService
	{
		Task<GetMovieAverageRatingDTO> GetAverageRating(int MovieID);
		Task<IEnumerable<GetMovieAverageRatingDTO>> GetAllRatings();
		Task<IEnumerable<GetMovieRatingDTO>> GetRatingFromMovie(int ID);
	}
}
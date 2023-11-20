using MovieRating.Domain.Entities;

namespace MovieRating.Domain.Contracts
{
	public interface IMovieRatingRepository
	{
		IQueryable<MovieRate> GetRatesFromMovie(int MovieID);
		IQueryable<MovieRate> GetAllRates();

		Task DeleteRates(int MovieID);
	}
}

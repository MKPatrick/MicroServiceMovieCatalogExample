using MovieRating.Domain.Contracts;
using MovieRating.Domain.Entities;
using MovieRating.Infrastructure.Data;

namespace MovieRating.Infrastructure.Repository
{
	public class MovieRateRepository : IMovieRatingRepository
	{
		private readonly MovieRatingDatabaseContext movieRatingDatabaseContext;

		public MovieRateRepository(MovieRatingDatabaseContext movieRatingDatabaseContext)
		{
			this.movieRatingDatabaseContext = movieRatingDatabaseContext;
		}

		public IQueryable<MovieRate> GetRatesFromMovie(int MovieID)
		{
			return movieRatingDatabaseContext.MovieRates.Where(x => x.MovieID == MovieID);
		}

		public IQueryable<MovieRate> GetAllRates()
		{
			return movieRatingDatabaseContext.MovieRates;
		}

		public async Task DeleteRates(int MovieID)
		{
			movieRatingDatabaseContext.MovieRates.RemoveRange(GetRatesFromMovie(MovieID));
		}
	}
}
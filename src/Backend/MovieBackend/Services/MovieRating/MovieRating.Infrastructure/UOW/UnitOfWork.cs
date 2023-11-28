using MovieRating.Domain.Contracts;
using MovieRating.Infrastructure.Data;

namespace MovieRating.Infrastructure.UOW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MovieRatingDatabaseContext movieRatingDatabase;

		public UnitOfWork(MovieRatingDatabaseContext movieRatingDatabase)
		{
			this.movieRatingDatabase = movieRatingDatabase;
		}

		public async Task<int> SaveChangesAsync()
		{
			return await movieRatingDatabase.SaveChangesAsync();
		}
	}
}
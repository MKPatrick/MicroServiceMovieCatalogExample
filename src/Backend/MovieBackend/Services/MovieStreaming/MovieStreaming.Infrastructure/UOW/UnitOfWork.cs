using MovieStreaming.Domain.Contracts;
using MovieStreaming.Infrastructure.Data;

namespace MovieStreaming.Infrastructure.UOW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MovieStreamingDatabaseContext movieRatingDatabase;

		public UnitOfWork(MovieStreamingDatabaseContext movieRatingDatabase)
		{
			this.movieRatingDatabase = movieRatingDatabase;
		}
		public async Task<int> SaveChangesAsync()
		{
			return await movieRatingDatabase.SaveChangesAsync();
		}
	}
}

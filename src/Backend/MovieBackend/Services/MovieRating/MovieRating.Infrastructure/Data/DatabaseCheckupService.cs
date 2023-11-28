using Microsoft.EntityFrameworkCore;

namespace MovieRating.Infrastructure.Data
{
	public class DatabaseCheckupService
	{
		private readonly MovieRatingDatabaseContext movieDatabaseContext;

		public DatabaseCheckupService(MovieRatingDatabaseContext movieDatabaseContext)
		{
			this.movieDatabaseContext = movieDatabaseContext;
		}

		public async Task SetupDatabase()
		{
			var migrations = (await movieDatabaseContext.Database
			.GetPendingMigrationsAsync())
			.ToArray();

			if (migrations.Any())
			{
				await movieDatabaseContext.Database.MigrateAsync();
			}
		}
	}
}
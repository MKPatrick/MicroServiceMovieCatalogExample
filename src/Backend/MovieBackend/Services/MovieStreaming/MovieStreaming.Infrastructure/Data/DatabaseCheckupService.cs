using Microsoft.EntityFrameworkCore;

namespace MovieStreaming.Infrastructure.Data
{
	public class DatabaseCheckupService
	{
		private readonly MovieStreamingDatabaseContext movieDatabaseContext;

		public DatabaseCheckupService(MovieStreamingDatabaseContext movieDatabaseContext)
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
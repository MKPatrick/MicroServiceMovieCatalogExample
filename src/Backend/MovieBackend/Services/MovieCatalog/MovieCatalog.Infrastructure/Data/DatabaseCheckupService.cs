using Microsoft.EntityFrameworkCore;

namespace MovieCatalog.Infrastructure.Data
{
	public class DatabaseCheckupService
	{
		private readonly MovieDatabaseContext movieDatabaseContext;

		public DatabaseCheckupService(MovieDatabaseContext movieDatabaseContext)
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
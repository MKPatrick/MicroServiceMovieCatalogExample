using Microsoft.EntityFrameworkCore;
using MovieCatalog.Domain.Entities.Movie;
using System.Reflection;

namespace MovieCatalog.Infrastructure.Data
{
	public class MovieDatabaseContext : DbContext
	{
		private DbSet<Movie> Movies { get; set; }

		public MovieDatabaseContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
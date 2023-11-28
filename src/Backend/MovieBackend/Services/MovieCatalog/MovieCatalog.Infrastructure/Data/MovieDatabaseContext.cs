using Microsoft.EntityFrameworkCore;
using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Infrastructure.Data
{
	public partial class MovieDatabaseContext : DbContext
	{
		private DbSet<Movie> Movies { get; set; }

		public MovieDatabaseContext(DbContextOptions options) : base(options)
		{
		}
	}
}
using Microsoft.EntityFrameworkCore;
using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Infrastructure.Data
{
	public partial class MovieDatabaseContext : DbContext
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>().Property(x => x.Title).IsRequired();
			modelBuilder.Entity<Movie>().HasKey(x => x.ID);
			modelBuilder.Entity<Movie>().Property(x => x.MovieImage).IsRequired(false);
			modelBuilder.Entity<Movie>().OwnsOne(x => x.ReleaseDate);
		}
	}
}
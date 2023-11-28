using Microsoft.EntityFrameworkCore;
using MovieRating.Domain.Entities;
using System.Reflection;

namespace MovieRating.Infrastructure.Data
{
	public class MovieRatingDatabaseContext : DbContext
	{
		public DbSet<MovieRate> MovieRates { get; set; }

		public MovieRatingDatabaseContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
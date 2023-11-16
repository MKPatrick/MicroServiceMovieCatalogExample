using Microsoft.EntityFrameworkCore;
using MovieRating.Domain.Entities;

namespace MovieRating.Infrastructure.Data
{
	public partial class MovieRatingDatabaseContext : DbContext
	{
		public DbSet<MovieRate> MovieRates { get; set; }
		public MovieRatingDatabaseContext(DbContextOptions options) : base(options)
		{
		}
	}
}

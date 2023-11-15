using Microsoft.EntityFrameworkCore;

namespace MovieRating.Infrastructure.Data
{
	public class MovieRatingDatabaseContext : DbContext
	{
		public MovieRatingDatabaseContext(DbContextOptions options) : base(options)
		{
		}
	}
}

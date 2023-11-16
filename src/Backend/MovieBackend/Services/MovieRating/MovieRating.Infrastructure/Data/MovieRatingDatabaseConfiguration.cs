using Microsoft.EntityFrameworkCore;
using MovieRating.Domain.Entities;

namespace MovieRating.Infrastructure.Data
{
	public partial class MovieRatingDatabaseContext : DbContext
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
	//		modelBuilder.Entity<MovieRate>()
	//.Property(p => p.MovieRatedStar)
	//.HasConversion<int>();
			modelBuilder.Entity<MovieRate>()
	.HasKey(p => p.ID);


		}
	}
}

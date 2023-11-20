using Microsoft.EntityFrameworkCore;
using MovieStreaming.Domain.Entities;

namespace MovieStreaming.Infrastructure.Data
{
	public partial class MovieStreamingDatabaseContext
	{
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MovieStream>().HasIndex(x => x.MovieID).IsUnique();
		}
	}
}

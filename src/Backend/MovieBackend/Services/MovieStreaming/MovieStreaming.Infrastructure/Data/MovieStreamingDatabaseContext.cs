using Microsoft.EntityFrameworkCore;
using MovieStreaming.Domain.Entities;
using System.Reflection;

namespace MovieStreaming.Infrastructure.Data
{
	public class MovieStreamingDatabaseContext : DbContext
	{
		public MovieStreamingDatabaseContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public DbSet<MovieStream> MovieStreams { get; set; }
	}
}
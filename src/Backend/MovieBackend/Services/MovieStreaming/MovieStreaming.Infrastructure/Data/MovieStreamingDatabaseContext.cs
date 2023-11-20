using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieStreaming.Domain.Entities;

namespace MovieStreaming.Infrastructure.Data
{
	public partial class MovieStreamingDatabaseContext : DbContext
	{
        public MovieStreamingDatabaseContext(DbContextOptions options) : base(options)

		{
                
        }
        public DbSet<MovieStream> MovieStreams { get; set; }
	}
}

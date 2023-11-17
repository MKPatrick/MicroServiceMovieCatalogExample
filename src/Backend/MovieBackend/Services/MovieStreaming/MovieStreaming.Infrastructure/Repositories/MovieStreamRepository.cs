using MovieStreaming.Domain.Contracts;
using MovieStreaming.Domain.Entities;
using MovieStreaming.Infrastructure.Data;

namespace MovieStreaming.Infrastructure.Repositories
{
	public class MovieStreamRepository : BaseRepository<MovieStream>, IMovieStreamRepository
	{
		public MovieStreamRepository(MovieStreamingDatabaseContext context) : base(context)
		{
		}
	}
}

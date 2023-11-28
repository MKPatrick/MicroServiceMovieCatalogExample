using Microsoft.EntityFrameworkCore;
using MovieStreaming.Domain.Contracts;
using MovieStreaming.Domain.Entities;
using MovieStreaming.Infrastructure.Data;

namespace MovieStreaming.Infrastructure.Repositories
{
	public class MovieStreamRepository : BaseRepository<MovieStream>, IMovieStreamRepository
	{
		private readonly MovieStreamingDatabaseContext context;

		public MovieStreamRepository(MovieStreamingDatabaseContext context) : base(context)
		{
			this.context = context;
		}

		public Task DeleteStreamsByMovieID(int movieID)
		{
			context.MovieStreams.RemoveRange(context.MovieStreams.Where(x => x.MovieID == movieID));
			return Task.CompletedTask;
		}

		public Task<MovieStream?> GetStreamForMovieID(int movieID)
		{
			return context.MovieStreams.FirstOrDefaultAsync(x => x.MovieID == movieID);
		}
	}
}
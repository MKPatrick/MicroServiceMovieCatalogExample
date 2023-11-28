using MovieCatalog.Domain.Contracts;
using MovieCatalog.Domain.Entities.Movie;
using MovieCatalog.Infrastructure.Data;

namespace MovieCatalog.Infrastructure.Repositories
{
	public class MovieRepository : BaseRepository<Movie>, IMovieRepository
	{
		private readonly MovieDatabaseContext context;

		public MovieRepository(MovieDatabaseContext context) : base(context)
		{
			this.context = context;
		}

		public override async Task UpdateAsync(Movie entity)
		{
			var originalEntry = await base.GetByIdAsync(entity.ID);
			originalEntry.Title = entity.Title;
			originalEntry.Description = entity.Description;
			originalEntry.ReleaseDate.Year = entity.ReleaseDate.Year;
			originalEntry.ReleaseDate.Month = entity.ReleaseDate.Month;
			originalEntry.ReleaseDate.Day = entity.ReleaseDate.Day;
		}
	}
}
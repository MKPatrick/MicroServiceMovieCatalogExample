using MovieRating.Domain.Entities;
using MovieRating.Infrastructure.Data;
using SharedKernel;

namespace MovieRating.Infrastructure.Repository
{
	public class MovieRatingRepository : BaseRepository<MovieRate>, IBaseRepository<MovieRate>
	{
		public MovieRatingRepository(MovieRatingDatabaseContext context) : base(context)
		{
		}
	}
}

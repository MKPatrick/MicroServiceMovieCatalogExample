using MovieRating.Domain.Contracts;
using MovieRating.Domain.Entities;
using MovieRating.Infrastructure.Data;
using SharedKernel;

namespace MovieRating.Infrastructure.Repository
{
	public class RatingRepository : BaseRepository<MovieRate>, IRatingRepository
	{
		public RatingRepository(MovieRatingDatabaseContext context) : base(context)
		{
		}
	}
}

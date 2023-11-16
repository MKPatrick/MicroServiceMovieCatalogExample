using MovieRating.Domain.Entities;
using SharedKernel;

namespace MovieRating.Domain.Contracts
{
	public interface IRatingRepository : IBaseRepository<MovieRate>
	{
	}
}

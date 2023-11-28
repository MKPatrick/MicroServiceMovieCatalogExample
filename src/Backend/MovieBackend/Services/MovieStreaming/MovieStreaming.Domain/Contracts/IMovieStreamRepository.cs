using MovieStreaming.Domain.Entities;
using SharedKernel;

namespace MovieStreaming.Domain.Contracts
{
	public interface IMovieStreamRepository : IBaseRepository<MovieStream>
	{
		Task DeleteStreamsByMovieID(int movieID);

		Task<MovieStream?> GetStreamForMovieID(int movieID);
	}
}
using MovieCatalog.Domain.Entities.Movie;
using SharedKernel;

namespace MovieCatalog.Domain.Contracts
{
	public interface IMovieRepository : IBaseRepository<Movie>
	{
	}
}
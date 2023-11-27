using MovieCatalog.Domain.Entities.Movie;

namespace MovieCatalog.Application.DTO.Movie
{
	public record UpdateMovieDTO(int ID, IFormFile MovieImage, string Title, string Description, DateRelease ReleaseDate)
	{
		public static object TestValidate(AddMovieDTO model)
		{
			throw new NotImplementedException();
		}
	}
}
